using OttoMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OttoMail.Tests
{
    public class EmailTest
    {
        [Fact]
        public void GetSubjectTest()
        {
            //Arrange
            var email = new Email();
            email.Subject = "Test";
            //Act
            var result = email.Subject;

            //Assert
            Assert.Equal("Test", result);   
        }
    }
}
