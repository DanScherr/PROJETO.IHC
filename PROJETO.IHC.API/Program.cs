using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;
using PROJETO.IHC.Repository;
using PROJETO.IHC.Repository.Repositories;
using PROJETO.IHC.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =  ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo { Title = "PROJETO IHC API", Version = "v1" });
});

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("connection string"));

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

builder.Services.AddScoped(typeof(IColaboradorRepository), typeof(ColaboradorRepository));
builder.Services.AddScoped(typeof(IEmpresaRepository), typeof(EmpresaRepository));
builder.Services.AddScoped(typeof(IHabilidadeRepository), typeof(HabilidadeRepository));
builder.Services.AddScoped(typeof(IProjetoRepository), typeof(ProjetoRepository));
builder.Services.AddScoped(typeof(IPropostaRepository), typeof(PropostaRepository));

builder.Services.AddTransient(typeof(IColaboradorService), typeof(ColaboradorService));
builder.Services.AddTransient(typeof(IEmpresaService), typeof(EmpresaService));
builder.Services.AddTransient(typeof(IHabilidadeService), typeof(HabilidadeService));
builder.Services.AddTransient(typeof(IProjetoService), typeof(ProjetoService));
builder.Services.AddTransient(typeof(IPropostaService), typeof(PropostaService));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PROJETO.IHC.API V1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

app.MapControllers();

app.Run();
