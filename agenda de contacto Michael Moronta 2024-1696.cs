Console.WriteLine("Bienvenido a mi lista de Contactes");



bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");
                foreach (var id in ids)
                {
                    var isBestFriend = bestFriends[id];

                    string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                    Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                }

            }
            break;
        case 3: //search
            {
                buscar_contacto(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 4: //modify
            {
                modificar_contactos(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 5: //delete
            {
                eliminar_contactos(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 6:
            Console.WriteLine("El programa ha cerrado..");
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}
static void buscar_contacto(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Ingrese el nombre o el apellido del contacto que quiere buscar");
    string buscar_c = Console.ReadLine().ToLower();
    var encontrar = ids.Where(id => names[id].ToLower().Contains(buscar_c) || lastnames[id].ToLower().Contains(buscar_c)).ToList();
    if (encontrar.Count ==0) 
    {
        Console.WriteLine("El contacto ingresado no esta registrado.");
        return;
    }
    Console.WriteLine("Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine("____________________________________________________________________________________________________________________________");
    foreach (var id in encontrar)
    {
        string isBestFriendStr = bestFriends[id] ? "Si" : "No";
        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
    }


}
static void modificar_contactos(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Ingrese el nombre o el apellido del contacto que quiere modificar.");
    string contactoamodificar = Console.ReadLine().ToLower();
    var modificar = ids.Where(id => names[id].ToLower().Contains(contactoamodificar) || lastnames[id].ToLower().Contains(contactoamodificar)).ToList();
    if (modificar.Count ==0)
    {
        Console.WriteLine("El contacto ingresado no esta registrado.");
        return;
    }
    Console.WriteLine("Contacto a modificar");
    foreach (var id in modificar)
    {
        Console.WriteLine($"ID: {id}, Nombre: {names[id]}, Apellido: {lastnames[id]}, Direccion: {addresses[id]}, Numero: {telephones[id]}, Email: {emails[id]}, Edad:{ages[id]}, Mejor amigo: {bestFriends[id]}");

        Console.WriteLine("Ingrese el nuevo nombre (Dejar vacio si no quiere cambiar.: ");
        string newname = Console.ReadLine();
        Console.WriteLine("\nIngrese el nuevo apellido (Dejar vacio si no quiere cambiar.): ");
        string newlastnames = Console.ReadLine();
        Console.WriteLine("\nIngrese la nueva Direccion (Dejar vacio si no quiere cambiar.): ");
        string newaddresses = Console.ReadLine();
        Console.WriteLine("\nIngrese el nuevo numero de telefono (Dejar vacio si no quiere cambiar.): ");
        string newtelephones = Console.ReadLine();
        Console.WriteLine("\nIngrese el nuevo email (Dejar vacio si no quiere cambiar.): ");
        string newEmail = Console.ReadLine();
        Console.WriteLine("\nIngrese la nueva edad (Dejar vacio si no quiere cambiar.): ");
        string newages = Console.ReadLine();
        Console.WriteLine("\nModificar si es mejor amigo: (1.si  2.no): ");
        string newbestFriends = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newname)) names[id]=newname;
        if (!string.IsNullOrWhiteSpace(newlastnames)) lastnames[id]=newlastnames;
        if (!string.IsNullOrWhiteSpace(newaddresses)) addresses[id]=newaddresses;
        if (!string.IsNullOrWhiteSpace(newtelephones)) telephones[id]=newtelephones;
        if (!string.IsNullOrWhiteSpace(newEmail)) emails[id]=newEmail;
        if (int.TryParse(newages, out int edad)) ages[id] = edad;
        if (newbestFriends == "1") bestFriends[id] = true;
        if (newbestFriends == "2") bestFriends[id] = false;
        Console.WriteLine("Contacto modificado correctamente");
    }
}
static void eliminar_contactos(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Ingrese el numero del contacto que quiere eliminar." );
    string telphoneTodelet = Console.ReadLine();
    int idToDelete = telephones.FirstOrDefault(x => x.Value == telphoneTodelet).Key;

    if (idToDelete==0)
    {
        Console.WriteLine("No se encontro ese numero de telefono, intenta de nuevo..");
        return;
    }
    ids.Remove(idToDelete);
    names.Remove(idToDelete);
    lastnames.Remove(idToDelete);
    addresses.Remove(idToDelete);
    telephones.Remove(idToDelete);
    emails.Remove(idToDelete);
    ages.Remove(idToDelete);
    bestFriends.Remove(idToDelete);
    Console.WriteLine("El Contacto ha sido eliminado correctamnte.");
}