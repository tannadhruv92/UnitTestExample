using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundamentals.ServiceInterface;
using Fundamentals.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestExamples.UnitTests.Services
{
    [TestClass]
    public class DirectApiDownloadServiceTests
    {
        private Mock<IWebClient> webClient;
        private Mock<IDBRepository> dBRepository;
        private DirectApiDownloadService directApiDownloadService;

        [TestInitialize]
        public void Setup()
        {
            webClient = new Mock<IWebClient>();
            dBRepository = new Mock<IDBRepository>();
            directApiDownloadService  = new  DirectApiDownloadService(webClient.Object, dBRepository.Object); 
        }

        [TestCleanup]
        public void TearDown()
        {
            directApiDownloadService = null;
            webClient = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DownloadPages_NoUrls_ThrowsArgumentNullException()
        {
            //Arrange
            
            //Act
            directApiDownloadService.DownloadPages(null, null);

            //Assert
        }

        [TestMethod]
        public void DownloadPages_PassUrl_PageDownload()
        {
            //Arrange 
            string url = "https://stackoverflow.com/questions/599275/how-can-i-download-html-source-in-c-sharp";
            string path = "D:\\test.html";
            webClient.Setup(s => s.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            //Act
            directApiDownloadService.DownloadPages(url, path);

            //Assert
            webClient.Verify(x => x.DownloadFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void DownloadPages_FileNotDownload_DetailsNotSavedInDB()
        {
            //Arrange 
            string url = "https://stackoverflow.com/questions/599275/how-can-i-download-html-source-in-c-sharp";
            string path = "D:\\test.html";

            webClient.Setup(x => x.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            //Act
            directApiDownloadService.DownloadPages(url, path);

            //Assert
            dBRepository.Verify(x => x.SaveDetailsToDB(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void DownloadPages_FileDownloaded_DetailsSavedInDB()
        {
            //Arrange 
            string url = "https://stackoverflow.com/questions/599275/how-can-i-download-html-source-in-c-sharp";
            string path = "D:\\test.html";

            webClient.Setup(x => x.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            //Act
            directApiDownloadService.DownloadPages(url, path);

            //Assert
            dBRepository.Verify(x => x.SaveDetailsToDB(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
