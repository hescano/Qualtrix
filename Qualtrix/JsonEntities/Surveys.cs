using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Qualtrix.JsonEntities
{
    [DataContract]
    public class Element
    {

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "ownerId")]
        public string OwnerId { get; set; }

        [DataMember(Name = "lastModified")]
        public string LastModified { get; set; }

        [DataMember(Name = "isActive")]
        public bool IsActive { get; set; }
    }

    [DataContract]
    public class Result
    {

        [DataMember(Name = "elements")]
        public IList<Element> Elements { get; set; }

        [DataMember(Name = "nextPage")]
        public object NextPage { get; set; }
    }

    [DataContract]
    public class Meta
    {

        [DataMember(Name = "httpStatus")]
        public string HttpStatus { get; set; }

        [DataMember(Name = "notice")]
        public string Notice { get; set; }
    }

    [DataContract]
    public class SurveyResult
    {

        [DataMember(Name = "result")]
        public Result Result { get; set; }

        [DataMember(Name = "meta")]
        public Meta Meta { get; set; }
    }
}
