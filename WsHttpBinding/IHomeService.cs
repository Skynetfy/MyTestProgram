using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;


namespace WsHttpBinding
{
    [ServiceContract]
    public interface IHomeService
    {
        [OperationContract]
        int GetLength(string name);

        [OperationContract]
        Student Update(Student model);
    }

    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}
