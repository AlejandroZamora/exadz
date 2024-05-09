namespace product.DB; 

 public record Producto 
 {
   public int Id {get; set;} 
   public string ? Name { get; set; }
   public string ? Descripcion { get; set; }
 }

 public class ProductoDB
 {
   private static List<Producto> _producto = new List<Producto>()
   {
     new Producto{ Id=1, Name="Monitor Asus", Descripcion="Monitor 4K" },
     new Producto{ Id=2, Name="Teclado HyperX", Descripcion="Teclado mecanico"},
     new Producto{ Id=3, Name="Mause Hyper X", Descripcion="Mause Hyper X Custom"} 
   };

   public static List<Producto> GetProducto() 
   {
     return _producto;
   } 

   public static Producto ? GetProducto(int id) 
   {
     return _producto.SingleOrDefault(Producto => Producto.Id == id);
   } 

   public static Producto CreateProducto(Producto Producto) 
   {
     _producto.Add(Producto);
     return Producto;
   }

   public static Producto UpdateProducto(Producto update) 
   {
     _producto = _producto.Select(producto =>
     {
       if (producto.Id == update.Id)
       {
         producto.Name = update.Name;
         producto.Descripcion= update.Descripcion;
       }
       return producto;
     }).ToList();
     return update;
   }

   public static void RemoveProducto(int id)
   {
     _producto = _producto.FindAll(producto => producto.Id != id).ToList();
   }
 }