using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestUI5WebApp.Data;

namespace TestUI5WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ODataController
    {
        private List<Person> m_data;

        public PersonsController()
        {
            // Testdata from https://www.generatedata.com/
            var baseData = new Person[]{
                new Person{ ID = 1, Name = "Kellie Maldonado", Street = "P.O. Box 463, 4666 Congue St.", ZipCode = "48760", City = "Genzano di Lucania" },
                new Person{ ID = 2, Name = "Tara Galloway", Street = "Ap #449-6115 Tellus St.", ZipCode = "82275", City = "Houffalize" },
                new Person{ ID = 3, Name = "Kieran Estrada", Street = "Ap #285-8388 A Road", ZipCode = "90683", City = "Santo Stefano Quisquina" },
                new Person{ ID = 4, Name = "Carter Wilkerson", Street = "8228 Vestibulum St.", ZipCode = "15149", City = "San Cristóbal de la Laguna" },
                new Person{ ID = 5, Name = "Yoshi Key", Street = "6893 Morbi St.", ZipCode = "33287", City = "Latinne" },
                new Person{ ID = 6, Name = "Kai Martin", Street = "P.O. Box 235, 6468 Nisl. Rd.", ZipCode = "94801", City = "Castor" },
                new Person{ ID = 7, Name = "Vera Stevens", Street = "P.O. Box 473, 8205 Libero St.", ZipCode = "38173", City = "Abbateggio" },
                new Person{ ID = 8, Name = "Patricia Goff", Street = "P.O. Box 801, 9801 At St.", ZipCode = "02142", City = "Gallodoro" },
                new Person{ ID = 9, Name = "Tucker Perry", Street = "P.O. Box 566, 1587 Varius St.", ZipCode = "21071", City = "Siverek" },
                new Person{ ID = 10, Name = "Amanda Stephenson", Street = "Ap #110-7138 Nec Avenue", ZipCode = "44663", City = "Fermont" },
                new Person{ ID = 11, Name = "Kadeem Joseph", Street = "149-1833 Ac Av.", ZipCode = "36989", City = "Antalya" },
                new Person{ ID = 12, Name = "Dawn Dalton", Street = "P.O. Box 548, 2938 Ut, Avenue", ZipCode = "80616", City = "Trois-Rivires" },
                new Person{ ID = 13, Name = "Beck Rowe", Street = "231-7203 Mauris Road", ZipCode = "10393", City = "Landeck" },
                new Person{ ID = 14, Name = "Austin Hayes", Street = "5809 Sit Avenue", ZipCode = "38477", City = "Ch‰tillon" },
                new Person{ ID = 15, Name = "Amal Nielsen", Street = "Ap #746-3121 Eros Rd.", ZipCode = "24926", City = "Pozantı" },
                new Person{ ID = 16, Name = "Kalia Estes", Street = "247-8181 Ipsum Road", ZipCode = "81475", City = "Wardha" },
                new Person{ ID = 17, Name = "Drake Cote", Street = "621-3823 Quisque St.", ZipCode = "23850", City = "Promo-Control" },
                new Person{ ID = 18, Name = "Kieran Meyers", Street = "905-3904 Per Rd.", ZipCode = "58057", City = "Ville de Maniwaki" },
                new Person{ ID = 19, Name = "Drew Mullins", Street = "1843 Mauris Avenue", ZipCode = "43882", City = "Dongelberg" },
                new Person{ ID = 20, Name = "Kimberly Santos", Street = "Ap #293-9858 Vestibulum Av.", ZipCode = "84061", City = "Pichilemu" },
                new Person{ ID = 21, Name = "Alfonso Dickerson", Street = "125-1132 Interdum Street", ZipCode = "63827", City = "Lauw" },
                new Person{ ID = 22, Name = "Destiny Cochran", Street = "Ap #402-1460 Malesuada Avenue", ZipCode = "50761", City = "Enschede" },
                new Person{ ID = 23, Name = "Benedict Weiss", Street = "1143 Praesent Rd.", ZipCode = "27186", City = "Cariboo Regional District" },
                new Person{ ID = 24, Name = "Cole Mullen", Street = "Ap #765-6877 Donec St.", ZipCode = "70433", City = "Vlissegem" },
                new Person{ ID = 25, Name = "Jasmine Wagner", Street = "543-5645 Quis St.", ZipCode = "51928", City = "Wokingham" },
                new Person{ ID = 26, Name = "Imelda Donovan", Street = "P.O. Box 490, 3583 A, St.", ZipCode = "09443", City = "Prince George" },
                new Person{ ID = 27, Name = "Erich Spears", Street = "Ap #364-5568 Sit St.", ZipCode = "26639", City = "Oromocto" },
                new Person{ ID = 28, Name = "Clark Atkins", Street = "583-6782 Dignissim. St.", ZipCode = "71212", City = "Vancouver" },
                new Person{ ID = 29, Name = "Wing Snyder", Street = "P.O. Box 832, 8142 Nullam Road", ZipCode = "80039", City = "Ayr" },
                new Person{ ID = 30, Name = "Rogan Watkins", Street = "Ap #725-7720 Dolor. Av.", ZipCode = "82681", City = "Lewiston" },
                new Person{ ID = 31, Name = "Tatum Callahan", Street = "1750 Posuere, Road", ZipCode = "61126", City = "Algeciras" },
                new Person{ ID = 32, Name = "Travis Kent", Street = "119-314 Mauris Rd.", ZipCode = "71601", City = "Cabano" },
                new Person{ ID = 33, Name = "Wesley Noble", Street = "P.O. Box 254, 2316 Netus St.", ZipCode = "82237", City = "Argenteuil" },
                new Person{ ID = 34, Name = "Levi Burt", Street = "319-8426 Purus, Avenue", ZipCode = "44039", City = "Tirúa" },
                new Person{ ID = 35, Name = "Kylie Moses", Street = "760-4526 Vulputate Avenue", ZipCode = "38790", City = "Leiden" },
                new Person{ ID = 36, Name = "Dieter Small", Street = "7097 Molestie Av.", ZipCode = "37416", City = "Roxboro" },
                new Person{ ID = 37, Name = "Aubrey Caldwell", Street = "6400 Ridiculus Av.", ZipCode = "75989", City = "Trento" },
                new Person{ ID = 38, Name = "Simon Sanford", Street = "P.O. Box 942, 476 Eget Rd.", ZipCode = "54903", City = "Koblenz" },
                new Person{ ID = 39, Name = "Zelenia Sheppard", Street = "Ap #512-6989 Vivamus Ave", ZipCode = "98382", City = "Emmen" },
                new Person{ ID = 40, Name = "Eagan Mcdowell", Street = "3399 Amet St.", ZipCode = "46797", City = "Renlies" },
                new Person{ ID = 41, Name = "Uma Weiss", Street = "P.O. Box 198, 2414 Donec Rd.", ZipCode = "88485", City = "Norfolk" },
                new Person{ ID = 42, Name = "Daniel Gray", Street = "Ap #782-2764 Magna, Ave", ZipCode = "81850", City = "Raurkela Civil Township" },
                new Person{ ID = 43, Name = "Reed Blackburn", Street = "Ap #818-4357 At St.", ZipCode = "24233", City = "Stornaway" },
                new Person{ ID = 44, Name = "Ainsley Snider", Street = "P.O. Box 688, 1534 Dui. Avenue", ZipCode = "81110", City = "Castelbaldo" },
                new Person{ ID = 45, Name = "Brian Wise", Street = "Ap #988-4461 Mus. Ave", ZipCode = "80732", City = "Rock Springs" },
                new Person{ ID = 46, Name = "Joshua Lamb", Street = "430-2390 Cursus Rd.", ZipCode = "91075", City = "Blenheim" },
                new Person{ ID = 47, Name = "Kyra Cruz", Street = "Ap #726-1674 Augue Road", ZipCode = "62060", City = "Genk" },
                new Person{ ID = 48, Name = "Axel Cooke", Street = "932-2998 Consequat Avenue", ZipCode = "68279", City = "Oostkerke" },
                new Person{ ID = 49, Name = "Faith Christian", Street = "933-4467 Mattis. Avenue", ZipCode = "47080", City = "Açailândia" },
                new Person{ ID = 50, Name = "Buffy Walls", Street = "Ap #380-6381 Aliquam St.", ZipCode = "65017", City = "Roveredo in Piano" },
                new Person{ ID = 51, Name = "Zachary Randall", Street = "P.O. Box 569, 7179 Risus, Av.", ZipCode = "32836", City = "Wisbech" },
                new Person{ ID = 52, Name = "Malachi Wilcox", Street = "126-5824 Magna Road", ZipCode = "52321", City = "Murdochville" },
                new Person{ ID = 53, Name = "Nathaniel Parks", Street = "P.O. Box 672, 3453 Et, Rd.", ZipCode = "75319", City = "Grosseto" },
                new Person{ ID = 54, Name = "McKenzie Dennis", Street = "146-5030 Nonummy Rd.", ZipCode = "92244", City = "Destelbergen" },
                new Person{ ID = 55, Name = "Imogene Gentry", Street = "P.O. Box 910, 7515 Faucibus. St.", ZipCode = "79777", City = "Moorsel" },
                new Person{ ID = 56, Name = "Molly Turner", Street = "P.O. Box 828, 3371 Dolor Street", ZipCode = "11585", City = "Ilhéus" },
                new Person{ ID = 57, Name = "Rylee Joseph", Street = "975-5644 Nam St.", ZipCode = "94262", City = "Clermont-Ferrand" },
                new Person{ ID = 58, Name = "Naida Rivera", Street = "Ap #134-9080 Augue Street", ZipCode = "50657", City = "Reinbek" },
                new Person{ ID = 59, Name = "Kalia Hancock", Street = "P.O. Box 791, 5722 Nulla Av.", ZipCode = "04369", City = "Coventry" },
                new Person{ ID = 60, Name = "Kaye Russo", Street = "Ap #999-8952 Faucibus Ave", ZipCode = "94055", City = "Pogliano Milanese" },
                new Person{ ID = 61, Name = "Elijah Lindsay", Street = "Ap #199-3838 Nec St.", ZipCode = "67188", City = "Bruck an der Mur" },
                new Person{ ID = 62, Name = "Freya Woodward", Street = "P.O. Box 657, 2934 Sed Avenue", ZipCode = "26100", City = "Abergavenny" },
                new Person{ ID = 63, Name = "Jason Gilmore", Street = "444-9684 Mollis. St.", ZipCode = "98197", City = "Kalyan" },
                new Person{ ID = 64, Name = "Lucy Lewis", Street = "P.O. Box 523, 5317 Mi, St.", ZipCode = "09221", City = "Froidchapelle" },
                new Person{ ID = 65, Name = "Jayme Cox", Street = "848-191 Dictum Avenue", ZipCode = "35593", City = "Drogenbos" },
                new Person{ ID = 66, Name = "Macy Rhodes", Street = "986-1574 Ante. St.", ZipCode = "74615", City = "Gorzów Wielkopolski" },
                new Person{ ID = 67, Name = "Shoshana Hall", Street = "6169 Libero Rd.", ZipCode = "90922", City = "Hilo" },
                new Person{ ID = 68, Name = "Cheyenne Bush", Street = "P.O. Box 370, 4063 Praesent Rd.", ZipCode = "42956", City = "San Maurizio Canavese" },
                new Person{ ID = 69, Name = "Zeph Rowe", Street = "3628 Proin Road", ZipCode = "83728", City = "Las Vegas" },
                new Person{ ID = 70, Name = "Marsden Bender", Street = "6551 Feugiat St.", ZipCode = "28007", City = "Vosselaar" },
                new Person{ ID = 71, Name = "Elmo Davidson", Street = "6090 Dui. Road", ZipCode = "28996", City = "Bear" },
                new Person{ ID = 72, Name = "Farrah Hendricks", Street = "Ap #326-5080 Euismod Rd.", ZipCode = "46352", City = "Dereham" },
                new Person{ ID = 73, Name = "Griffith Barlow", Street = "P.O. Box 641, 2405 Ac Road", ZipCode = "67183", City = "Follina" },
                new Person{ ID = 74, Name = "Aileen Reyes", Street = "156-8559 Mauris Ave", ZipCode = "31947", City = "Amelia" },
                new Person{ ID = 75, Name = "Fay Simpson", Street = "Ap #339-9976 Blandit. Ave", ZipCode = "29283", City = "Hulshout" },
                new Person{ ID = 76, Name = "Isadora Cooper", Street = "3861 Mollis. St.", ZipCode = "32313", City = "Eckville" },
                new Person{ ID = 77, Name = "Jade Wong", Street = "P.O. Box 462, 6315 In St.", ZipCode = "40761", City = "Kanpur" },
                new Person{ ID = 78, Name = "Carson Vaughan", Street = "930-8296 Adipiscing. Ave", ZipCode = "26770", City = "Salcito" },
                new Person{ ID = 79, Name = "Madonna Le", Street = "113-5136 Non Road", ZipCode = "44968", City = "Groot-Bijgaarden" },
                new Person{ ID = 80, Name = "Mari Love", Street = "148-3966 Vel Road", ZipCode = "89574", City = "Dunkerque" },
                new Person{ ID = 81, Name = "Neville Ayala", Street = "P.O. Box 107, 7991 Augue, Ave", ZipCode = "75819", City = "Sobral" },
                new Person{ ID = 82, Name = "Walter Brennan", Street = "P.O. Box 392, 4974 Ultricies St.", ZipCode = "49434", City = "Wardha" },
                new Person{ ID = 83, Name = "Yoshi Kaufman", Street = "P.O. Box 186, 2854 Nisl Avenue", ZipCode = "97755", City = "Falkirk" },
                new Person{ ID = 84, Name = "Kendall Richard", Street = "667-9105 Non Rd.", ZipCode = "44833", City = "Thorn" },
                new Person{ ID = 85, Name = "Galena Spencer", Street = "299-4505 Quisque St.", ZipCode = "33862", City = "Hohenems" },
                new Person{ ID = 86, Name = "Steel Mcguire", Street = "726-9953 Nec, Rd.", ZipCode = "73091", City = "Valladolid" },
                new Person{ ID = 87, Name = "Maryam Blake", Street = "P.O. Box 533, 700 Laoreet Avenue", ZipCode = "35862", City = "Pemberton" },
                new Person{ ID = 88, Name = "Theodore Shaffer", Street = "Ap #855-8398 Suspendisse Ave", ZipCode = "20790", City = "Viddalba" },
                new Person{ ID = 89, Name = "Heidi Obrien", Street = "844 Nec Avenue", ZipCode = "98883", City = "Latisana" },
                new Person{ ID = 90, Name = "Owen Norris", Street = "P.O. Box 607, 8535 Sem. St.", ZipCode = "47119", City = "Assebroek" },
                new Person{ ID = 91, Name = "Macy Freeman", Street = "Ap #935-7125 Volutpat Street", ZipCode = "57574", City = "Lauterach" },
                new Person{ ID = 92, Name = "Mohammad Morrow", Street = "Ap #313-8133 Duis Street", ZipCode = "58139", City = "Subiaco" },
                new Person{ ID = 93, Name = "Jaquelyn Wiley", Street = "4231 Est St.", ZipCode = "39038", City = "Manfredonia" },
                new Person{ ID = 94, Name = "Joseph Conrad", Street = "163-1412 Justo Street", ZipCode = "57556", City = "Wismar" },
                new Person{ ID = 95, Name = "Thane Reeves", Street = "P.O. Box 412, 8766 Eleifend Ave", ZipCode = "48423", City = "Dubbo" },
                new Person{ ID = 96, Name = "Keane Underwood", Street = "Ap #357-1398 Turpis Road", ZipCode = "38701", City = "María Elena" },
                new Person{ ID = 97, Name = "Jackson Horton", Street = "706-9245 Suspendisse Av.", ZipCode = "97258", City = "Cortil-Noirmont" },
                new Person{ ID = 98, Name = "Leo Schneider", Street = "Ap #672-9494 Venenatis Rd.", ZipCode = "05030", City = "Bazzano" },
                new Person{ ID = 99, Name = "Hadassah Swanson", Street = "Ap #850-8966 Molestie Ave", ZipCode = "31289", City = "Livingston" },
                new Person{ ID = 100, Name = "Beck Johnston", Street = "Ap #452-9428 Rutrum St.", ZipCode = "70886", City = "St. Ives" }
            };

            // Duplicate testdata
            m_data = new List<Person>(20 * baseData.Length);
            for(var loop=0; loop<20; loop++)
            {
                foreach(var actPerson in baseData)
                {
                    m_data.Add(new Person()
                    {
                        ID = actPerson.ID + (loop * baseData.Length),
                        Name = actPerson.Name,
                        Street = actPerson.Street,
                        ZipCode = actPerson.ZipCode,
                        City = actPerson.City
                    });
                }
            }
        }

        [EnableQuery]
        public IActionResult Get() => this.Ok(m_data);
    }
}