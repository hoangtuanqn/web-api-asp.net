using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ShopDBProduct;
using ShopDBProduct.Middlewares;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();


// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           // app.UseAuthentication();  cần có cái này trước Authorization
           options.TokenValidationParameters = new TokenValidationParameters
           {
               /*
                    - Kiểm tra ai là người phát hành token này? Có phải server của mình hay không?
                    - Đọc giá trị của "iss": Lấy chuỗi định danh nhà phát hành từ token
                */
               ValidateIssuer = true,

               /*
                    - Kiểm tra xem ai là người tạo ra token
                    - Kiểm tra key "aud" với cái đã cấu hình trong server
                */
               ValidateAudience = true,

               /*
                    - Kiểm tra hạn sử dụng token
                    - Lấy thời gian hiện tại của exp so với t/gian của server
                */
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               // thông tin cấu hình
               ValidIssuer = builder.Configuration["JWT:Issuer"],
               ValidAudience = builder.Configuration["JWT:Audience"],

               // secure key
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
               ClockSkew = TimeSpan.Zero // không cho lệch giờ
           };
       });





var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

//app.UseHttpsRedirection(); // https

// Get Connect String

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
