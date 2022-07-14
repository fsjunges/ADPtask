using ADPtask.Options;
using ADPtask.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ADPtaskApiOptions>(builder.Configuration.GetSection("ADPtaskAPI"));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IGetCalculationTaskService, GetCalculationTaskService>();
builder.Services.AddScoped<ISolveCalculationTask, SolveCalculationTask>();
builder.Services.AddHttpClient<ISubmitCalculationTask, SubmitCalculationTask>();
builder.Services.AddScoped<ICalculationTaksService, CalculationTaksService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
