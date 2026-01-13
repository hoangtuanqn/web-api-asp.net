# Web API .NET

## 1. Tìm hiểu về Unit Of Work

### Document

1. [Kết hợp Unit Of Work và Repository Pattern trong ASP.NET MVC](https://tedu.com.vn/lap-trinh-aspnet/ket-hop-unit-of-work-va-repository-pattern-trong-aspnet-mvc-37.html)

### Khái niệm
__Unit Of Work__ được sử dụng để đảm bảo nhiều hành động như insert, update, delete...được thực thi trong cùng một transaction thống nhất. 
Nói đơn giản hơn, nghĩa là khi một hành động của người dùng tác động vào hệ thống, tất cả các hành động như insert, update, delete... __phải thực hiện xong và đều thành công__ thì mới gọi là một transaction thành công. 
Gói tất cả các hành động đơn lẻ vào một transaction để đảm bảo tính toàn vẹn dữ liệu.

![Hình ảnh về Unit Of Work. Trích trong tài liệu ở trên](https://i.ibb.co/svphmJGj/Repository-Pattern2.jpg)

Cách sử dụng nó

![Hình ảnh về Unit Of Work. Trích trong tài liệu ở trên](https://i.ibb.co/fVr4fSNG/Repository-Pattern4.jpg)

---

## 2. Tìm hiểu về Generic Repository

### Document

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

5. Đăng ký DI trong program.cs