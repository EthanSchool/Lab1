using System;
using System.Linq;

namespace DriversExam {
	internal static class Program {
		private static readonly char[] Answers = "BDAACABACDBCDADCCBDA".ToCharArray();

		private static void Main() {
			Console.WriteLine("Press Esc to exit");
			while(true) {
				char[] studentAnswers = FancyConsole.PromptArray(20, new[] {'A', 'B', 'C', 'D'});

				if(studentAnswers == null)
					return;
				int[] wrong = Answers.Select((value, index) => new {value, index})
					.Where(x => x.value != studentAnswers[x.index])
					.Select(x => x.index + 1)
					.ToArray();
				int correct = 20 - wrong.Length;

				string t = correct / studentAnswers.Length > .75f ? "Passed" : "Failed";
				Console.WriteLine($"Student {t}, {correct}/{studentAnswers.Length} correct, Incorrect Questions: {string.Join(',', wrong)}");
			}
		}
	}
}