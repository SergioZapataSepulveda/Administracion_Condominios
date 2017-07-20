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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public string ListarResidente()
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Residente>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarResidente());
            return salida.ToString();
        }

        public bool ValidarLogin(string LOGusuario, string LOGpassword)
        {
            Residente aux = new Residente();
            return aux.ValidarLogin(LOGusuario, LOGpassword);
        }

        public int ID_desde_LogUser(string LOGusuario)
        {
            Residente aux = new Residente();
            return aux.ID_desde_LogUser(LOGusuario);
        }

        public string Nombre_desde_LogUser(string LOGusuario)
        {
            Residente aux = new Residente();
            return aux.Nombre_desde_LogUser(LOGusuario);
        }

        public string CargoEnDirectiva(string LOGusuario)
        {
            Residente aux = new Residente();
            return aux.CargoEnDirectiva(LOGusuario);
        }


        public bool CreateResidente(string Rut)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Residente));
            StringReader lector = new StringReader(Rut);
            Residente nuevoUsuario = (Residente)serializador.Deserialize(lector);
            return nuevoUsuario.CreateResidente();

        }

        public bool DeleteResidente(string Rut)
        {
            Residente user = new Residente() { Rut_Residente = Rut };
            return user.DeleteResidente();
        }

        //Funcionario 
        public bool ValidarLoginFuncionario(string LOGusuario, string LOGpassword)
        {
            Funcionario aux = new Funcionario();
            return aux.ValidarLoginFuncionario(LOGusuario, LOGpassword);
        }

        public int ID_desde_LogUser_Funcionario(string LOGusuario)
        {
            Funcionario aux = new Funcionario();
            return aux.ID_desde_LogUser_Funcionario(LOGusuario);
        }

        public string Nombre_desde_LogUser_Funcionario(string LOGusuario)
        {
            Funcionario aux = new Funcionario();
            return aux.Nombre_desde_LogUser_Funcionario(LOGusuario);
        }

        public string CargoEnCondominio(string LOGusuario)
        {
            Funcionario aux = new Funcionario();
            return aux.CargoEnCondominio(LOGusuario);
        }

    }
}
