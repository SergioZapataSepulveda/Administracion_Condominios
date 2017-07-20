using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Caso14.Negocio;
using System.Xml.Serialization;
using System.IO;

namespace Servicios 
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: agregue aquí sus operaciones de servicio


        // RESIDENTE
        [OperationContract]
        string ListarResidente();
         

        [OperationContract]
        bool ValidarLogin(string LOGusuario, string LOGpassword);


        [OperationContract]
        int ID_desde_LogUser(string LOGusuario);


        [OperationContract]
        string Nombre_desde_LogUser(string LOGusuario);


        [OperationContract]
        string CargoEnDirectiva(string LOGusuario);


        [OperationContract]
        bool CreateResidente(string Rut);
        

        [OperationContract]
        bool DeleteResidente(string Rut); 


        // FUNCIONARIO
        [OperationContract]
        bool ValidarLoginFuncionario(string LOGusuario, string LOGpassword);


        [OperationContract]
        int ID_desde_LogUser_Funcionario(string LOGusuario);


        [OperationContract]
        string Nombre_desde_LogUser_Funcionario(string LOGusuario);


        [OperationContract]
        string CargoEnCondominio(string LOGusuario); 




    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
