namespace WebApplication1.Models
{
    public enum AccessLevel
    {
        FullAccess,            // Адміністратор
        IterationManagement,   // Scrum Master
        TaskManagement,        // Team Lead
        TaskExecution,         // Розробник
        RestrictedAccess       // Сторонній розробник
    }
}