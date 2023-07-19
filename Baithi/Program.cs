using Baithi;

ProductController productController = new ProductController();
while (true)
{

    Console.WriteLine("\n=============Menu==========");
    Console.WriteLine("o 1. Add product records\r\no 2. Display product records\r\no 3. Delete product by Id\r\no 4. Exit");
   

    Console.Write("Your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            productController.CreateNewProducts();
            Console.WriteLine("Successfully added new!");
            break;
        case 2:
            productController.ViewAll();
            break;
        case 3:
            productController.DeleteProducts();
            Console.WriteLine("Successful delete!");
            break;
        case 4:
            break;
    }

}