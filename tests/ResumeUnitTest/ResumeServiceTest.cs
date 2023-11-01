using Autofac.Extras.Moq;
using Moq;

namespace ResumeUnitTest
{
    public class ResumeServiceTests
    {
        private AutoMock _mock { get; set; }
        private Mock<IResumeService> _resumeServiceMock;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _mock = AutoMock.GetLoose();
        }




        [SetUp]
        public void Setup()
        {

        }
        [OneTimeTearDown] public void Teardown() 
        {
            _mock?.Dispose();
        }

        [Test]
        public void GetCvTemplate_IdDataTypeTest()
        {
            int id = 1;
           


            Assert.Pass();
        }
    }
}