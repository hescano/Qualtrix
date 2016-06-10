using Qualtrix.Helpers;
using System;
using System.Collections.Generic;
using Qualtrix.JsonEntities;

namespace Qualtrix.Model
{
    /// <summary>
    /// Represents a qualtrics survey.
    /// </summary>
    public class Survey
    {
        //Properties and private members
        private readonly Connection _connection;
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set;  }
        public DateTime LastModified { get; set; }
        public bool IsActive { get; set; }

        //Constructors
        public Survey(Connection connection)
        {
            _connection = connection;
        }

        public Survey(string dataCenterId, string apiToken)
        {
            _connection = new Connection(dataCenterId, apiToken);
        }

        public Survey()
        {
        }

        /// <summary>
        /// Gets a list of all surveys available to the user.
        /// </summary>
        /// <returns>Returns IEnumerable of Survey objects.</returns>
        public IEnumerable<Survey> ListSurveys()
        {
            var content = HttpHelper.Get("/API/v3/surveys", _connection);
            if (!string.IsNullOrEmpty(content))
            {
                var surveysResult = JSONHelper<SurveyResult>.Deserialize(content);

                if (surveysResult?.Result?.Elements.Count > 0)
                {
                    foreach (var survey in surveysResult.Result.Elements)
                    {
                        yield return (Survey)survey;
                    }
                }
            }
        }

        /// <summary>
        /// Converts a SurveyResult element into a Survey object.
        /// </summary>
        /// <param name="survey">Returns a Survey object.</param>
        public static explicit operator Survey(Element survey)
        {
            if(survey!= null)
            {
                return new Survey
                {
                    Id = survey.Id,
                    Name = survey.Name,
                    OwnerId = survey.OwnerId,
                    LastModified = DateTime.Parse(survey.LastModified),
                    IsActive = survey.IsActive
                };
            }

            return null;
        }
    }
}
