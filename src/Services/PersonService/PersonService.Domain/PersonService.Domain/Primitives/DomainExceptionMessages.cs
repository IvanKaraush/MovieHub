namespace Domain.Primitives;

public class DomainExceptionMessages
{
    public const string ReferalNotFoundException = "Такого реферала не существует";
    public const string ReferalAlreadyExistFoundException = "Такой реферал уже существует";
    public const string InvalidPasswordException = "Пароль не может содержать спец. символы";
    public const string InvalidNameException = "Имя не может содержать спец. символы";
    public const string InvalidEmailException = "Email введён некорректно";
}