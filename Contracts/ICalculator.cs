using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contracts
{
    [ServiceContract]
    //[ServiceContract(Name = "CalculatorService", Namespace = "http://www.arvtech.com/"
    //    , CallbackContract = typeof(ICallback))]
    public interface ICalculator
    {
        [OperationContract]
        //[OperationContract(IsOneWay = true)]
        void Add1(double x, double y);

        [OperationContract]
        double Add(double x, double y);

        [OperationContract]
        double Subtract(double x, double y);

        [OperationContract]
        double Multiply(double x, double y);

        [OperationContract]
        double Divide(double x, double y);
    }
}
