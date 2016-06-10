using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Qualtrix.Helpers;

namespace Qualtrix.Model.Tests
{
    [TestClass]
    public class SurveyTests
    {
        [TestMethod]
        public void ListSurveysTest()
        {
            var survey = new Survey(ConfigurationHelper.DataCenterId, ConfigurationHelper.XApiToken);
            var surveys = survey.ListSurveys().ToList();
            Assert.IsTrue(surveys.Any());
        }
    }
}