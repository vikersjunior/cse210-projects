public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
            return _text;

        // Preserve trailing punctuation; replace only the word characters with underscores
        string core = _text.TrimEnd('.', ',', ';', ':', '!', '?', '"', '\'', ')');
        string trailing = _text.Substring(core.Length);
        return new string('_', core.Length) + trailing;
    }
}
