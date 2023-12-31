using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//AddSingleton<>:(); birisi senden ICourseService istersen arka planda CourseManager s�n�f�n� 1 kereye mahsus new'le ve new'lenmi� olan� ICourseService istenen heryerde g�nder.1milyon tane yerde bile ihtiya� olsa ayn� newlenmi� CoursManager'i g�nder. Yani 1 kere bir referans numaras� olu�tur �rne�in // 101  olsun ve heryere o referans numaras�n� g�nder.

//Autofac bize AOP yap�s�n� sunar.
//Autofac, Ninject, CastleWindsor, StructureMap, LightInject DryInject ---> IoC Container
//AOP =>  Bir metodun �n�nde sonunda o metod hata verdi�inde o hatalar�n yaz�ld��� yerdir. Log'lar�n tutuldu�u yerdir diyebiliriz.
builder.Services.AddSingleton<ICourseService, CourseManager>();
builder.Services.AddSingleton<ICourseDal, EfCourseDal>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
