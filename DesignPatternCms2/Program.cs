using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCms2
{
    class Program
    {

        static RestaurantOrder CreateOrder()
        {
            Console.Clear();
            Console.WriteLine("Servitörens namn:");
            string namn = Console.ReadLine();
            Console.WriteLine("Bord nummer:");
            int tableNo = Convert.ToInt32(Console.ReadLine());
            var order = new RestaurantOrder
            {
                TableNumber = tableNo,
                Servant = namn,
                OrderStatus = RestaurantOrder.Status.Received,
                OrderParts = new List<RestaurantOrderRow>()
            };

            while (true)
            {
                Console.WriteLine("Produkt att lägga till (ex hamburgertallrik):");
                string prod = Console.ReadLine();
                Console.WriteLine("Antal");
                int count = Convert.ToInt32(Console.ReadLine());
                order.OrderParts.Add(new RestaurantOrderRow { Count=count, Product=prod  });
                Console.WriteLine("Lägga till fler J/N?");
                if (Console.ReadLine().ToLower() != "j")
                    break;
            }
            return order;
        }

        static void ShowHuvudMeny()
        {
            var allOrders = new List<RestaurantOrder>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"1. Show orders
2. Add order               
3. Change order status
9. Exit
");
                Console.WriteLine("Vad vill du göra?");
                int res = Convert.ToInt32(Console.ReadLine());
                if(res == 2)
                {
                    allOrders.Add(CreateOrder());
                }
                else if(res == 1)
                {
                    ListOrders(allOrders);
                }
                if (res == 9)
                    break;
            }
        }

        private static void ListOrders(List<RestaurantOrder> allOrders)
        {
            Console.Clear();
            int i = 1;
            foreach (string name in Enum.GetNames(typeof(RestaurantOrder.Status)))
            {
                Console.WriteLine($"{i} {name}");
                i++;
            }
            Console.WriteLine("Typ?");
            int sel = Convert.ToInt32(Console.ReadLine());
            var status = (RestaurantOrder.Status) sel-1;

            foreach(var order in allOrders.Where(o=>o.OrderStatus == status))
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"   TABLE {order.TableNumber}      SERVANT: {order.Servant} ");
                foreach(var row in order.OrderParts)
                {
                    Console.WriteLine($"            {row.Product}     {row.Count} ");
                }
            }
            Console.WriteLine("-Det var alla-");
            Console.WriteLine("Trycke ENTER för att fortsätta");
            Console.ReadLine();

        }

        static void Main(string[] args)
        {
            ShowHuvudMeny();
        }
    }
}
