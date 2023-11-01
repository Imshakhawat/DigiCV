using Autofac.Extras.Moq;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.Utilities;
using CVBuilder.Infrastructure.Service;
using Microsoft.Extensions.Options;
using Moq;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Infrastructure.Tests
{
    public class ResumeServiceTest
    {
        private AutoMock _mock { get; set; }
        private Mock<IResumeService> _resumeServiceMock;
        private IResumeService _resumeService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _mock = AutoMock.GetLoose();
        }




        [SetUp]
        public void Setup()
        {
            _resumeServiceMock =  _mock.Mock<IResumeService>();
            _resumeService = _mock.Create<ResumeService>();
        }

        [TearDown]
        public void TearDown()
        {
            _resumeServiceMock.Reset();
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _mock?.Dispose();
        }

        [Test]
        public void GetCvTemplate_IdDataTypeTest()
        {
            int id = 1;
            int expected_id = 1;

            _resumeServiceMock.Setup(x => x.GetCvTemplate2(1)).Verifiable();
            _resumeService.GetCvTemplate2(1);
            _resumeServiceMock.VerifyAll();
        }
    }
}
