using SharpHook.Native;

namespace KeyCat.SharedKernel;

public static class KeyCodeExtensions
{
    public static Key? ToKey(this MouseButton mouseButton) =>
        mouseButton switch
        {
            MouseButton.Button1 => Key.LButton,
            MouseButton.Button2 => Key.RButton,
            MouseButton.Button3 => Key.MButton,
            MouseButton.Button4 => Key.XButton1,
            MouseButton.Button5 => Key.XButton2,
            _ => null,
        };

    public static Key? ToKey(this KeyCode keyCode) =>
        keyCode switch
        {
            // Modifier Keys
            KeyCode.VcLeftShift or KeyCode.VcRightShift => Key.Shift,
            KeyCode.VcLeftControl or KeyCode.VcRightControl => Key.Control,
            KeyCode.VcLeftAlt or KeyCode.VcRightAlt => Key.Alt,
            KeyCode.VcLeftMeta or KeyCode.VcRightMeta => Key.Meta,

            // Function Keys
            KeyCode.VcF1 => Key.F1,
            KeyCode.VcF2 => Key.F2,
            KeyCode.VcF3 => Key.F3,
            KeyCode.VcF4 => Key.F4,
            KeyCode.VcF5 => Key.F5,
            KeyCode.VcF6 => Key.F6,
            KeyCode.VcF7 => Key.F7,
            KeyCode.VcF8 => Key.F8,
            KeyCode.VcF9 => Key.F9,
            KeyCode.VcF10 => Key.F10,
            KeyCode.VcF11 => Key.F11,
            KeyCode.VcF12 => Key.F12,

            // Control Keys
            KeyCode.VcBackspace => Key.Backspace,
            KeyCode.VcTab => Key.Tab,
            KeyCode.VcEnter or KeyCode.VcNumPadEnter => Key.Enter,
            KeyCode.VcPause => Key.Pause,
            KeyCode.VcCapsLock => Key.CapsLock,
            KeyCode.VcEscape => Key.Escape,
            KeyCode.VcSpace => Key.Space,
            KeyCode.VcPageUp => Key.PageUp,
            KeyCode.VcPageDown => Key.PageDown,
            KeyCode.VcEnd => Key.End,
            KeyCode.VcHome => Key.Home,
            KeyCode.VcLeft => Key.LeftArrow,
            KeyCode.VcUp => Key.UpArrow,
            KeyCode.VcRight => Key.RightArrow,
            KeyCode.VcDown => Key.DownArrow,
            KeyCode.VcPrintScreen => Key.PrintScreen,
            KeyCode.VcInsert => Key.Insert,
            KeyCode.VcDelete => Key.Delete,
            KeyCode.VcNumLock => Key.NumLock,
            KeyCode.VcScrollLock => Key.ScrollLock,

            // Number Keys
            KeyCode.Vc0 or KeyCode.VcNumPad0 => Key.Key0,
            KeyCode.Vc1 or KeyCode.VcNumPad1 => Key.Key1,
            KeyCode.Vc2 or KeyCode.VcNumPad2 => Key.Key2,
            KeyCode.Vc3 or KeyCode.VcNumPad3 => Key.Key3,
            KeyCode.Vc4 or KeyCode.VcNumPad4 => Key.Key4,
            KeyCode.Vc5 or KeyCode.VcNumPad5 => Key.Key5,
            KeyCode.Vc6 or KeyCode.VcNumPad6 => Key.Key6,
            KeyCode.Vc7 or KeyCode.VcNumPad7 => Key.Key7,
            KeyCode.Vc8 or KeyCode.VcNumPad8 => Key.Key8,
            KeyCode.Vc9 or KeyCode.VcNumPad9 => Key.Key9,

            // NumPad Keys
            KeyCode.VcNumPadMultiply => Key.Multiply,
            KeyCode.VcNumPadAdd => Key.Add,
            KeyCode.VcNumPadSubtract => Key.Minus,
            KeyCode.VcNumPadDivide => Key.Slash,
            KeyCode.VcNumPadDecimal => Key.Period,

            // Alphabet Keys
            KeyCode.VcA => Key.A,
            KeyCode.VcB => Key.B,
            KeyCode.VcC => Key.C,
            KeyCode.VcD => Key.D,
            KeyCode.VcE => Key.E,
            KeyCode.VcF => Key.F,
            KeyCode.VcG => Key.G,
            KeyCode.VcH => Key.H,
            KeyCode.VcI => Key.I,
            KeyCode.VcJ => Key.J,
            KeyCode.VcK => Key.K,
            KeyCode.VcL => Key.L,
            KeyCode.VcM => Key.M,
            KeyCode.VcN => Key.N,
            KeyCode.VcO => Key.O,
            KeyCode.VcP => Key.P,
            KeyCode.VcQ => Key.Q,
            KeyCode.VcR => Key.R,
            KeyCode.VcS => Key.S,
            KeyCode.VcT => Key.T,
            KeyCode.VcU => Key.U,
            KeyCode.VcV => Key.V,
            KeyCode.VcW => Key.W,
            KeyCode.VcX => Key.X,
            KeyCode.VcY => Key.Y,
            KeyCode.VcZ => Key.Z,

            // Special Characters
            KeyCode.VcBackQuote => Key.Tilde,           // `
            KeyCode.VcMinus => Key.Minus,               // -
            KeyCode.VcEquals => Key.Equal,              // =
            KeyCode.VcOpenBracket => Key.LeftBracket,   // [
            KeyCode.VcCloseBracket => Key.RightBracket, // ]
            KeyCode.VcBackslash => Key.Backslash,       // \
            KeyCode.VcSemicolon => Key.Semicolon,       // ;
            KeyCode.VcQuote => Key.Apostrophe,          // '
            KeyCode.VcComma => Key.Comma,               // ,
            KeyCode.VcPeriod => Key.Period,             // .
            KeyCode.VcSlash => Key.Slash,               // /

            // Other Keys
            KeyCode.VcAppBrowser => Key.Application,
            KeyCode.VcHelp => Key.Help,
            KeyCode.VcSleep => Key.Sleep,

            // Media and Browser Keys
            KeyCode.VcVolumeMute => Key.VolumeMute,
            KeyCode.VcVolumeDown => Key.VolumeDown,
            KeyCode.VcVolumeUp => Key.VolumeUp,
            KeyCode.VcMediaNext => Key.MediaNextTrack,
            KeyCode.VcMediaPrevious => Key.MediaPreviousTrack,
            KeyCode.VcMediaStop => Key.MediaStop,
            KeyCode.VcMediaPlay => Key.MediaPlayPause,
            KeyCode.VcAppMail => Key.LaunchMail,
            KeyCode.VcMediaSelect => Key.LaunchMediaSelect,
            KeyCode.VcApp1 => Key.LaunchApp1,
            KeyCode.VcApp2 => Key.LaunchApp2,
            KeyCode.VcBrowserBack => Key.BrowserBack,
            KeyCode.VcBrowserForward => Key.BrowserForward,
            KeyCode.VcBrowserRefresh => Key.BrowserRefresh,
            KeyCode.VcBrowserStop => Key.BrowserStop,
            KeyCode.VcBrowserSearch => Key.BrowserSearch,
            KeyCode.VcBrowserFavorites => Key.BrowserFavorites,
            KeyCode.VcBrowserHome => Key.BrowserHome,

            _ => null
        };

}