using Microsoft.Extensions.DependencyInjection;
using NgCinema.ConsoleApp.Utilities;

namespace NgCinema.ConsoleApp.Menu
{
    public class Menu
    {
        private readonly ServiceProvider _provider;

        public Menu(ServiceProvider provider)
        {
            _provider = provider;
        }

        public void Start()
        {
            Console.WriteLine("********************Bievenidos a NG-Cine ********************");
            ChooseOption();
        }

        public void ChooseOption()
        {
            bool exit = false;

            while(!exit)
            {
                Console.WriteLine("Ingrese el numero de las siguientes opciones\n- 0) Salir\n- 1) Crear Funcion\n- 2) Listar Funciones");
                int option = ValidData.AskForNumber("Opcion",2);
                switch (option)
                {
                    case 1:
                        _provider.GetService<Options>().Create();
                        break;
                    case 2:
                        _provider.GetService<Options>().Consult();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Apagando el sistema....");
        }
    }
}
