using System;

namespace TP10.Models
{
    public class Persona
    {
        private int _DNI;
        private string _Apellido;
        private string _Nombre;
        private int _NumeroTramite;
        private int _IdEstablecimiento;
        private bool _Voto;


        public int DNI {
            get{
                return _DNI;
            }
            set{
                _DNI=value;
            }
        }

        public string Apellido {
            get{
                return _Apellido;
            }
            set{
                _Apellido=value;
            }
        }

        public string Nombre {
            get{
                return _Nombre;
            }
            set{
                _Nombre=value;
            }
        }
        public int NumeroTramite {
            get{
                return _NumeroTramite;
            }
            set{
                _NumeroTramite=value;
            }
        }
        public int IdEstablecimiento {
            get{
                return _IdEstablecimiento;
            }
            set{
                _IdEstablecimiento=value;
            }
        }

        public bool Voto {
            get{
                return _Voto;
            }
            set{
                _Voto=value;
            }
        }





      
    }
}
