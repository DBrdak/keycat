namespace KeyCat.SharedKernel;

public sealed record Key
{
    public string Code { get; init; }

    private Key(string code) => Code = code;

    public static string AsSequence(IEnumerable<Key> keys) => string.Join("+", keys.Select(k => k.Code));

    // Mouse Keys
    public static Key LButton => new("LButton");
    public static Key RButton => new("RButton");
    public static Key MButton => new("MButton");
    public static Key XButton1 => new("XButton1");
    public static Key XButton2 => new("XButton2");

    // Modifier Keys
    public static Key Control => new("Control");
    public static Key Shift => new("Shift");
    public static Key Alt => new("Alt");
    public static Key Meta => new("Meta");

    // Function Keys
    public static Key F1 => new("F1");
    public static Key F2 => new("F2");
    public static Key F3 => new("F3");
    public static Key F4 => new("F4");
    public static Key F5 => new("F5");
    public static Key F6 => new("F6");
    public static Key F7 => new("F7");
    public static Key F8 => new("F8");
    public static Key F9 => new("F9");
    public static Key F10 => new("F10");
    public static Key F11 => new("F11");
    public static Key F12 => new("F12");

    // Control Keys
    public static Key Backspace => new("Backspace");
    public static Key Tab => new("Tab");
    public static Key Enter => new("Enter");
    public static Key Pause => new("Pause");
    public static Key CapsLock => new("CapsLock");
    public static Key Escape => new("Escape");
    public static Key Space => new("Space");
    public static Key PageUp => new("PageUp");
    public static Key PageDown => new("PageDown");
    public static Key End => new("End");
    public static Key Home => new("Home");
    public static Key LeftArrow => new("LeftArrow");
    public static Key UpArrow => new("UpArrow");
    public static Key RightArrow => new("RightArrow");
    public static Key DownArrow => new("DownArrow");
    public static Key PrintScreen => new("PrintScreen");
    public static Key Insert => new("Insert");
    public static Key Delete => new("Delete");
    public static Key NumLock => new("NumLock");
    public static Key ScrollLock => new("ScrollLock");

    // Number Keys
    public static Key Key0 => new("0");
    public static Key Key1 => new("1");
    public static Key Key2 => new("2");
    public static Key Key3 => new("3");
    public static Key Key4 => new("4");
    public static Key Key5 => new("5");
    public static Key Key6 => new("6");
    public static Key Key7 => new("7");
    public static Key Key8 => new("8");
    public static Key Key9 => new("9");

    // Alphabet Keys
    public static Key A => new("A");
    public static Key B => new("B");
    public static Key C => new("C");
    public static Key D => new("D");
    public static Key E => new("E");
    public static Key F => new("F");
    public static Key G => new("G");
    public static Key H => new("H");
    public static Key I => new("I");
    public static Key J => new("J");
    public static Key K => new("K");
    public static Key L => new("L");
    public static Key M => new("M");
    public static Key N => new("N");
    public static Key O => new("O");
    public static Key P => new("P");
    public static Key Q => new("Q");
    public static Key R => new("R");
    public static Key S => new("S");
    public static Key T => new("T");
    public static Key U => new("U");
    public static Key V => new("V");
    public static Key W => new("W");
    public static Key X => new("X");
    public static Key Y => new("Y");
    public static Key Z => new("Z");

    // Numpad Keys
    public static Key Multiply => new("*");
    public static Key Add => new("+");

    // Special Characters
    public static Key Tilde => new("`");
    public static Key Minus => new("-");
    public static Key Equal => new("=");
    public static Key LeftBracket => new("[");
    public static Key RightBracket => new("]");
    public static Key Backslash => new(@"\");
    public static Key Slash => new("/");
    public static Key Semicolon => new(";");
    public static Key Apostrophe => new("'");
    public static Key Quote => new("\"");
    public static Key Comma => new(",");
    public static Key Period => new(".");

    // Other Keys
    public static Key Application => new("Application");
    public static Key Select => new("Select");
    public static Key Print => new("Print");
    public static Key Execute => new("Execute");
    public static Key Help => new("Help");
    public static Key Sleep => new("Sleep");

    // Media and Browser Keys
    public static Key VolumeMute => new("VolumeMute");
    public static Key VolumeDown => new("VolumeDown");
    public static Key VolumeUp => new("VolumeUp");
    public static Key MediaNextTrack => new("MediaNextTrack");
    public static Key MediaPreviousTrack => new("MediaPreviousTrack");
    public static Key MediaStop => new("MediaStop");
    public static Key MediaPlayPause => new("MediaPlayPause");
    public static Key LaunchMail => new("LaunchMail");
    public static Key LaunchMediaSelect => new("LaunchMediaSelect");
    public static Key LaunchApp1 => new("LaunchApp1");
    public static Key LaunchApp2 => new("LaunchApp2");
    public static Key BrowserBack => new("BrowserBack");
    public static Key BrowserForward => new("BrowserForward");
    public static Key BrowserRefresh => new("BrowserRefresh");
    public static Key BrowserStop => new("BrowserStop");
    public static Key BrowserSearch => new("BrowserSearch");
    public static Key BrowserFavorites => new("BrowserFavorites");
    public static Key BrowserHome => new("BrowserHome");
}