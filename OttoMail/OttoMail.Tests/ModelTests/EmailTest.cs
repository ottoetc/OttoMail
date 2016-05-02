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
        [Fact]
        public void GetBodyTest()
        {
            var email = new Email();
            email.Body = "Test";

            var result = email.Body;

            Assert.Equal("Test", result);
        }
        [Fact]
        public void GetDateTest()
        {
            var email = new Email();

            var result = email.Date;

            Assert.Equal(DateTime.Now, result);
        }
        
    }
}
