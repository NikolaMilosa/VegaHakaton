using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Context;
using HandlerObjects.Command;
using Handlers.DeskHandlers;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Model;
using Moq;
using Repositories.Desks;
using Shouldly;
using Xunit;

namespace HandlersTests
{
    public class DeleteDeskHandlerTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public async Task ShouldDeleteDeskSuccessfully(int amountToInit, int oneToDelete)
        {
            var context = new AppDbContext(AppDbContextFactory.GetTestableOptions());
            ClearDbContext(context);

            for (int i = 0; i < amountToInit; i++)
            {
                context.Desks.Add(new Desk()
                {
                    Id = $"desk - {i}",
                    RoomId = "test room",
                    Order = i
                });
            }

            context.SaveChanges();

            var readRepo = new Mock<IDeskReadRepository>();
            readRepo.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns<string>(x => context.Desks.Find(x));
            readRepo.Setup(x => x.GetAll())
                .Returns(context.Desks);

            var writeRepo = new Mock<IDeskWriteRepository>();
            writeRepo.Setup(x => x.Delete(It.IsAny<Desk>(), It.IsAny<bool>()))
                .Callback<Desk, bool>((x, y) =>
                {
                    context.Desks.Remove(x);
                    context.SaveChanges();
                });
            writeRepo.Setup(x => x.UpdateRange(It.IsAny<IEnumerable<Desk>>(), It.IsAny<bool>()))
                .Callback<IEnumerable<Desk>, bool>((x, y) =>
                {
                    context.Desks.UpdateRange(x);
                    context.SaveChanges();
                });

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.GetRepository<IDeskReadRepository>())
                .Returns(readRepo.Object);
            uow.Setup(x => x.GetRepository<IDeskWriteRepository>())
                .Returns(writeRepo.Object);

            var deskToDelete = context.Desks.ToList()[oneToDelete];
            var handler = new DeleteDeskHandler(uow.Object);
            var request = new DeleteDeskCommand(deskToDelete.Id);

            var deletedId = await handler.Handle(request, CancellationToken.None);


            deletedId.ShouldBe(deskToDelete.Id);
            var orderedDesks = context.Desks.OrderBy(x => x.Order);
            for (int i = 0; i < orderedDesks.Count(); i++)
            {
                orderedDesks.ToList()[i].Order.ShouldBe(i);
            }
            deletedId.ShouldNotBeOneOf(context.Desks.Select(x => x.Id).ToArray());
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[]
            {
                16, 0
            };
            yield return new object[]
            {
                16, 10
            };
            yield return new object[]
            {
                16, 15
            };
        }

        public static void GenericRemoveSet<T>(DbSet<T> set) where T : class
        {
            foreach (var item in set)
            {
                set.Remove(item);
            }
        }

        protected void ClearDbContext(AppDbContext context)
        {
            var removeMethod = System.Reflection.MethodBase
                .GetCurrentMethod()
                .DeclaringType
                .GetMethod(nameof(GenericRemoveSet));

            var properties = context
                .GetType()
                .GetProperties()
                .Where(x => x.PropertyType.IsGenericType &&
                            x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var property in properties)
            {
                var genericArgument = property.PropertyType.GetGenericArguments();
                var typedRemove = removeMethod.MakeGenericMethod(genericArgument);
                typedRemove.Invoke(null, new object[] { property.GetValue(context) });
            }

            context.SaveChanges();
        }
    }
}
