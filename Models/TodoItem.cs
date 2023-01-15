namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string? Name { get; set; }

    public bool isCompleted { get; set; }
}

public class ChethanTodoItem : TodoItem { }
public class JagadishTodoItem : TodoItem { }
public class YeswanthTodoItem : TodoItem { }