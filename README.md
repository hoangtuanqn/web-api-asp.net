# Web API .NET

## 1. Tìm hiểu về Generic Repository
1. [Gentle introduction to Generic Repository Pattern with C#](https://dev.to/karenpayneoregon/gentle-introduction-to-generic-repository-pattern-with-c-1jn0)
2. [Generic Repository Pattern in C#](https://medium.com/@dnzcnyksl/generic-repository-pattern-in-c-354ec183dc84)
3. [Video học Udemy](https://www.udemy.com/course/bootcamp-backend-net-core-tu-co-ban-en-nang-cao/learn/lecture/46022605?start=3345#overview)
### Các bước để thực hiện

1. Tạo Interface dạng Generic __IGenericRepository<T\> where T : class__
2. Tạo class __implement interface ở Bước 1__ (VD: __GenericRepository<T\>__)
    
    1. Đưa __DataContext__ vào constructor của class __GenericRepository__
        > public class GenericRepository<T\> : IGenericRepository<T\> where T : class
    
    2. Implement lại các method ở interface


3. Tạo interface, vd __IProductRepository__ implement lại __IGenericRepository<T\>__ và truyền đối tượng cần dùng vào.
  
    VD: __IProductRepository : IGenericRepository<Product\>__

4. Tạo class kế thừa lại class ở bước 2 (__GenericRepository<T\>__) và implement interface ở bước 3 (__IProductRepository__)

    > public class ProductRepository : GenericRepository<Product\>, IProductRepository