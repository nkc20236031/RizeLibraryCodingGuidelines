// RizeLibraryCodingGuidelines

// General:
// - This guideline is a coding guideline for Unity C# scripts
// - It shows general rules for coding Unity C# scripts
// - Additionally, it describes local rules and readable code rules, but they are not necessarily mandatory
// - If there are any doubts, prioritize the team's style guide

// References:
// - [Unity Documentation Order of execution for event functions](https://docs.unity3d.com/2019.4/Documentation/Manual/ExecutionOrder.html)
// - [Unity Code Style Guide](https://github.com/thomasjacobsen-unity/Unity-Code-Style-Guide)
// - [Microsoft Ignite Common C# code conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
// - [C# at Google Style Guide](https://google.github.io/styleguide/csharp-style.html)

// Naming/Casing:
// - Use PascalCase unless otherwise specified (e.g., ExamplePlayerController, MaxHealth)
// - Use camelCase for local/private variables and parameters (e.g., examplePlayerController, maxHealth)
// - Avoid Hungarian notation
// - Avoid snake_case and kebab-case as much as possible
// - If there is a MonoBehaviour in the file, match the source file name
// - Do not abbreviate identifiers as much as possible (e.g., ✕Pl 〇Player, ✕Ene 〇Enemy, ✕rb2d 〇rigidbody2D)
// - Use all uppercase for two-letter acronyms (Input Output => IO) and abbreviations (Identifier => ID)
// - Write abbreviations of three or more letters in camelCase without abbreviating

// Formatting:
// - Use Allman style (with exceptions)
// - Insert a single space after commas (e.g., var a = 1, b = 2;)
// - Do not insert spaces inside parentheses (e.g., if (a == b) { })
// - Insert a space before curly braces (e.g., if (a == b) { })
// - Insert a space inside curly braces (e.g., if (a == b) { return; })
// - Always use curly braces (e.g., if (a == b) { })
// - Do not insert spaces before or after semicolons (e.g., var a = 1;)
// - Always include access modifiers (e.g., public, private, protected, internal)
// - Add sealed to classes that are not inherited (to clarify that they can be inherited)
// - Do not abbreviate methods with lambda expressions
// - Delete unused variables and methods

// Comments:
// - Use comments to fill gaps and explain "why" rather than just answering "what" and "how"
// - Place explanations next to the logic using comments
// - Use tooltips instead of comments for serialized fields (e.g., int, bool)
// - Avoid using regions (#region)
// - Use external references for legal information and licenses to save space
// - Write summary XML tags before public methods and functions to output documentation and IntelliSense
// - Insert a single space after // in comments (e.g., // comment)
// - Write TODO comments for unimplemented or planned implementations (e.g., // TODO:[planned implementation] comment)
// - Write BUG comments for bugs (e.g., // BUG:[bug] comment)

// Using:
// - Order: System-related ➝ Unity-related ➝ Others, all in alphabetical order
// - Delete unused namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using MyNamespace;

// Namespace:
// - Namespace naming convention: Write folder names after the Scripts folder in PascalCase
// - (e.g., Assets/Scripts/Character/Player becomes Character.Player)
namespace MyNamespace                                   // Namespace: PascalCase
{
    // Enum
    public enum MyEnum                                  // Enum: PascalCase
    {
        Yes,                                            // Enum value: PascalCase
        No,
    }

    // Interface
    public interface IMyInterface                       // Interface: Prefix with "I" + PascalCase
    {
        public void MyInterfaceMethod();                // Method: PascalCase
    }

    // Struct
    public struct MyStruct                              // Struct: PascalCase
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // Class
    public class MyClass : MonoBehaviour                // Class: PascalCase
    {
        // Local rule: Write headers if there are serialized fields
        // Local rule: Attach "Config" to headers of object or class attachment groups
        [Header("My Header Config")]                    // Header: Generally written in English
        // SerializeField
        // Local rule: No need to order serialized fields
        // Local rule: Write serialized fields at the top
        [SerializeField] private RigidBody2D _rigidBody2D;  // Serialized field: _camelCase

        // Local rule: Attach "Settings" to headers of variable groups
        [Header("My Header Settings")]
        // Local rule: Write other attributes except [SerializeField] on the line above the variable
        [Tooltip("Tooltip")] [Min(0)]                // Tooltip: Can be written in Japanese
        // Local rule: Write initial values even if they are default values
        [SerializeField] private int _myField = 0;

        // Local rule: Use snake_case for const variables (e.g., const_variable) *UPPER_SNAKE_CASE is less readable, so use snake_case
        // Local rule: Do not write initial values if they are default values
        private const int const_variable = 100;          // const field: snake_case
        private readonly int readonlyVariable = 100;    // readonly field: camelCase
        private static int StaticVariable;              // static field: PascalCase
        public int PublicVariable;                      // public field: PascalCase
        internal int internalVariable;                  // internal field: camelCase
        protected internal int protectedInternalVariable;   // protected internal field: camelCase
        protected int protectedVariable;                // protected field: camelCase
        // Local rule: Prefix private variables with "_" (underscore) e.g., _privateVariable
        private float _privateVariable = 0.0f;          // private field: _camelCase
        // Local rule: Prefix bool variables and methods with is, can, has, etc. (e.g., isGround, canJump)
        private bool _hasBool = false;

        // Delegate
        public delegate int Delegate();                 // Delegate: PascalCase

        // Event

        // Enum

        // Interface

        // Property
        public int PublicMyProperty { get; set; }       // public property: PascalCase
        private int privateMyProperty { get; set; }     // private property: camelCase

        // Awake method (Unity event)
        private void Awake()
        {
            // Get components from own object in Awake method
            var myComponent = GetComponent<MyComponent>();

            // Do not combine into one line like var a = 1, b = 2;
            var a = 1;
            var b = 2;
            var sum = Sum(a, b);
        }

        // Start method (Unity event)
        private void Start()
        {
            // Get components from external objects in Start method
            // Readable code: Do not write long code to the right
            // "." (dot, period) should be up to two per line, if more, break it up (do not break too much)
            var player = GameObject.Find("Player").GetComponent<Player>();
            player.PlayerMethod();

            // Readable code: Use if for positive cases and else for negative cases
            // Readable code: == true, == false are unnecessary
            if (IsGround())
            {

            }
            else
            {

            }

            // Readable code: Place variables on the left and constants on the right when comparing
            if (myField == 1)
            {

            }

            // Readable code: Correct early return
            // Do not use early return just because you do not want to write else
            if (IsGround())
            {
                MyMethod(1);
                return;
            }

            MyMethod(2);
        }

        // Readable code: Return bool variables in positive form
        private bool IsGround()
        {
            // Readable code: Early return
            // Exit methods as early as possible
            // Readable code: Always use curly braces. For one-line processing, attach "{" at the beginning and "}" at the end
            if (hasBool) { return false; }

            return true;
        }

        // FixedUpdate method (Unity event)
        private void FixedUpdate() { }

        // Update method (Unity event)
        private void Update()
        {
            MyMethod(1);
        }

        // Method                               // Method: PascalCase
        private void MyMethod(int e)                    // Parameter: camelCase
        {
            // Use var if the variable type is explicitly known
            var localVariable = "value";                // Local variable: camelCase
            int sum = Sum(1, 2);
        }

        // Write below the calling method. If there are multiple calling methods, write below the last calling method
        private int Sum(int a, int b)
        {
            return sum = a + b;
        }

        private void LateUpdate() { }

        private void OnTriggerEnter(Collider other) { }

        private void OnTriggerStay(Collider other) { }

        private void OnTriggerExit(Collider other) { }

        private void OnCollisionEnter(Collision collision) { }

        private void OnDrawGizmos() { }

        private void OnDrawGizmosSelected() { }

        private void OnEnable() { }

        private void OnDisable() { }

        private void OnDestroy() { }

        // Write at the end if the caller is only external
        // Local rule: Write summary XML tags for public methods
        /// <summary>
        /// Public method
        /// </summary>
        /// <param name="a">Parameter</param>
        public void MyPublicMethod(int a) { }

        // Struct

        // Class
    }

    // Serializable class
    [Serializable]
    public class MySerializableClass { }
}