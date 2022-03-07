using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.UnitOfWork;
using Model;
using Moq;
using Repositories.Desks;
using Services.RandomHexaGenerator;
using Shouldly;
using Xunit;

namespace ServicesTests
{
    public class GeneratorTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void ShouldGenerateANonexistingId(List<string> ids)
        {
            var desks = new List<Desk>();
            for (int i = 0; i < ids.Count; i++)
            {
                desks.Add(new Desk()
                {
                    Id = ids[i],
                    Order = i,
                    RoomId = "test"
                });
            }

            var deskRepoMoq = new Mock<IDeskReadRepository>();
            deskRepoMoq.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns<string>(query => desks.FirstOrDefault(y => y.Id == query));

            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(x => x.GetRepository<IDeskReadRepository>())
                .Returns(deskRepoMoq.Object);

            var generatedId = new Generator(uowMoq.Object).GenId<IDeskReadRepository, Desk>();

            generatedId.ShouldNotBeOneOf(desks.Select(x => x.Id).ToArray());
            generatedId.ShouldStartWith("621cce90");
            generatedId.Length.ShouldBe(24);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[]
            {
                new List<string>()
            };
            yield return new object[]
            {
                new List<string>()
                {
                    "621cce904343d3504b31255b",
                    "621cce90b707f8b3243a2917",
                    "621cce909b54e1187d9d1cc2",
                    "621cce90af817dc0d01cb474",
                    "621cce9040882facde168eec",
                    "621cce90d6255b1e889aa2ae",
                    "621cce90d9de7aa5bd527c08",
                    "621cce908b7bae8e06b776e5",
                    "621cce904fe28ca82550bc67",
                    "621cce90d1ccbdd3e7689298",
                    "621cce9053d869d4dddba7f2",
                    "621cce9091fc01f11eb1bbdd"
                }
            };
        }
    }
}
