using System;
using System.Collections.Generic;

namespace Chapter4.Examples
{
    class UndoStack
    {
        private readonly Stack<Action> undoStack = new Stack<Action>();

        public void Do(Action action)
        {
            undoStack.Push(action);
        }

        public void Undo()
        {
            if (undoStack.Count > 0)
            {
                var undo = undoStack.Pop();
                undo?.Invoke();
            }
        }
    }

    class TextEditor
    {
        private readonly UndoStack undoStack;
        public TextEditor(UndoStack undoStack)
        {
            this.undoStack = undoStack;
        }
        public string Text { get; private set; }

        public void EditText(string newText)
        {
            var previousText = Text;
            undoStack.Do(() =>
            {
                Text = previousText;
                Console.Write($"Undo:'{newText}'".PadRight(25));
                Console.WriteLine($"Text='{Text}'");
            });

            Text += newText;
            Console.Write($"Edit:'{newText}'".PadRight(25));
            Console.WriteLine($"Text='{Text}'");
        }
    }

    class StackExamples
    {

        public static void Main()
        {
            var undoStack = new UndoStack();
            var editor = new TextEditor(undoStack);
            editor.EditText("One day, ");
            editor.EditText("in a ");
            editor.EditText("city ");
            editor.EditText("near by ");

            undoStack.Undo(); // remove 'near by'
            undoStack.Undo(); // remove 'city'
            editor.EditText("land ");
            editor.EditText("far far away ");
        }
    }
}