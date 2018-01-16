using System;
using System.Collections.Generic;
using System.Linq;

namespace DriversExam {
	public static class FancyConsole {
		public static char[] PromptArray(int values, char[] validValues) {
			ClearCurrentLine();

			char[] data = new char[values];

			Console.Write(string.Join(',', data).Replace('\0', '_'));
			Console.SetCursorPosition(0, Console.CursorTop);

			while(data[values - 1] == '\0') {
				ConsoleKeyInfo input = Console.ReadKey(true);
				if(input.Key == ConsoleKey.Escape)
					return null;
				HandleKeyInput(data, validValues, input);
			}

			Console.WriteLine();

			return data;
		}

		private static void ClearCurrentLine() {
			int currentLine = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLine);
		}

		private static void HandleKeyInput(char[] data, IEnumerable<char> validValues, ConsoleKeyInfo input) {
			char key = char.ToUpper(input.KeyChar);
			int found = Array.IndexOf(data, '\0');

			if(input.Key == ConsoleKey.Backspace && found != 0) {
				data[found - 1] = '\0';

				Console.SetCursorPosition(0, Console.CursorTop);
				Console.Write(string.Join(',', data).Replace('\0', '_'));
				Console.SetCursorPosition((found - 1) * 2, Console.CursorTop);
			} else {
				if(!validValues.Contains(key)) return;
				data[found] = key;

				Console.SetCursorPosition(0, Console.CursorTop);
				Console.Write(string.Join(',', data).Replace('\0', '_'));
				Console.SetCursorPosition((found + 1) * 2, Console.CursorTop);
			}
		}
	}
}