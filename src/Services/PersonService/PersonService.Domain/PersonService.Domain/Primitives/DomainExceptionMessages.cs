namespace Domain.Primitives;

public class DomainExceptionMessages
{
    public const string ReferralNotFoundException = "Такого реферала не существует";
    public const string ReferralAlreadyExistFoundException = "Такой реферал уже существует";
    public const string InvalidPasswordException = "Пароль не может содержать спец. символы";
    public const string InvalidNameException = "Имя не может содержать спец. символы";
    public const string InvalidEmailException = "Email введён некорректно";
}