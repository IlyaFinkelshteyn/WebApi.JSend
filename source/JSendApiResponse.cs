using System.Runtime.Serialization;

namespace WebApi.JSend
{
    [DataContract]
    public class JSendApiResonse
    {
        [DataMember(EmitDefaultValue = false)]
        public object Data { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember]
        public string Status { get; set; }

        public JSendApiResonse(string status, object data = null, string message = null)
        {
            Status = status;
            Data = data;
            Message = message;
        }
    }
}