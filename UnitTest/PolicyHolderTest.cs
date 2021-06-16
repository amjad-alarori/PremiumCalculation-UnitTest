using System;
using System.Reflection;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Xunit;
using Moq;

namespace WindesheimAD2021AutoVerzekeringsPremie.UnitTest
{
    public class PolicyHolderTest
    {
        [Fact]
        public void ParseDateReturnDateTimeTest()
        {
            var parseDate = typeof(PolicyHolder).GetMethod("ParseDate", BindingFlags.NonPublic | BindingFlags.Static);
            var result = (DateTime) parseDate.Invoke(new DateTime(), new[] {"27-02-1994"});
            Assert.Equal(result, new DateTime(1994,02,27));
        }
        
        [Fact]
        public void AgeByDateFuture()
        {
            //Arrange
            var ageByDate = typeof(PolicyHolder).GetMethod("AgeByDate",
                BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            
            //Act
            var age = ageByDate.Invoke(null, new object?[] {DateTime.Today.AddYears(-3).AddMonths(-3)});
            
            //Assert 
            Assert.Equal(3,age);
        }
        
        [Fact]
        public void AgeByDatePast()
        {
            //Arrange
            var ageByDate = typeof(PolicyHolder).GetMethod("AgeByDate",
                BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            
            //Act
            var age = ageByDate.Invoke(null, new object?[] {DateTime.Today.AddYears(-3).AddMonths(3)});
            
            //Assert 
            Assert.Equal(2,age);
        }
      
        

}
}