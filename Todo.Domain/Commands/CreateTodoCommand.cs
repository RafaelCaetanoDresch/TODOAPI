﻿using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class CreateTodoCommand : Notifiable<Notification>, ICommand
{

    public CreateTodoCommand(){}

    public CreateTodoCommand(string? title, string? user, DateTime date)
    {
        Title = title;
        Date = date;
        User = user;
    }

    public string? Title { get; set; }
    public DateTime Date { get; set; }
    public string? User { get; set; }

    
    public void Validate()
    {
        AddNotifications(new Contract<CreateTodoCommand>()
            .Requires()
            .IsGreaterThan(Title, 3, "Title", "Descreva melhor esta tarefa")
            .IsGreaterThan(User, 5, "User", "Usuário inválido"));
    }
}
