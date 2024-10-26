// RizeLibraryCodingGuidelines

// General:
// - このガイドラインは、UnityのC#スクリプト向けコーディングガイドラインです
// - UnityのC#スクリプトのコーディングに関する一般的なルールを示しています
// - その他に、ローカルルールやリーダブルコードに関するルールも記述していますが、それらは必ずしも守る必要はありません
// - 疑問があるものに関しては、チーム内のスタイルガイドを優先してください

// References:
// - [Unity Documentation イベント関数の実況順序](https://docs.unity3d.com/ja/2019.4/Manual/ExecutionOrder.html)
// - [Unity Code Style Guide](https://github.com/thomasjacobsen-unity/Unity-Code-Style-Guide)
// - [Microsoft Ignite Common C# code conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
// - [C# at Google Style Guide 日本語訳](https://gist.github.com/hideyukisaito/d298075c63b97f56825b0d413d8e4dc5)

// Naming/Casing:
// - 特に断りのない限り、Pascalの大文字と小文字を使用する(例：ExamplePlayerController、MaxHealth など)
// - ローカル/プライベート変数、パラメータにはキャメルケース(examplePlayerController、maxHealthなど)を使用する
// - ハンガリー記法は避ける
// - スネークケース、ケバブケースは極力避ける
// - ファイル内にMonoBehaviourがある場合、ソースファイル名を一致させること。
// - 識別名は可能な限り省略しない(例：✕Pl 〇Player, ✕Ene 〇Enemy, ✕rb2d 〇rigidbody2D)
// - 2文字の頭字語(Input Output => IO)及び省略語(Identifier => ID)はすべて大文字にする
// - 3文字以上の略語はcamelCaseで省略せず記述する

// Formatting:
// - オールマトンスタイルを使用する(例外あり)
// - ,(カンマ)の後に半角スペースを1つ入れる(例：var a = 1, b = 2;)
// - ()(丸括弧)の中にスペースを入れない(例：if (a == b) { })
// - {}(波括弧)の前にスペースを入れる(例：if (a == b) { })
// - {}(波括弧)の中にスペースを入れる(例：if (a == b) { return; })
// - {}(波括弧)は必ず付ける(例：if (a == b) { })
// - ;(セミコロン)の前後にスペースを入れない(例：var a = 1;)
// - アクセス修飾子は必ずつける(例：public, private, protected, internal)
// - 継承しないクラスにはsealedを付ける(どれも継承しても良いと明記されるため)
// - メソッドはラムダ式で省略しない
// - 使用していない変数やメソッド等は削除する

// Comments:
// - 単に「何を」、「どのように 」と答えるのではなく、コメントによってギャップを埋め、「なぜ 」なのかを伝える
// - コメントを使用して、ロジックの隣に説明を置く
// - シリアライズされたフィールド(intやbool等の変数)には、コメントの代わりにツールチップを使用する
// - リージョン(#region)は避ける
// - 法的な情報やライセンスについては、外部リファレンスへのリンクを使用してスペースを節約する
// - パブリック・メソッドや関数の前にサマリーXMLタグを記述して、ドキュメントやインテリセンスを出力する
// - コメントは//の後にスペースを1つ入れる(例：// ○○)
// - 未実装・実装予定はTODOコメントを書く(例：// TODO:[実装予定] ○○)
// - 不具合・バグがある場合はBUGコメントを書く(例：// BUG:[不具合] ○○)

// Using:
// - 順序：System関連 ➝ Unity関連 ➝ その他の順番で、すべてアルファベット順
// - 使用していない名前空間は削除する
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

// 名前空間(Namespace):
// - 名前空間の命名規則：Scriptsフォルダ以降のフォルダ名をPascalCaseで記述する
// - (例：Assets/Scripts/Character/Playerの場合、Character.Playerになる)
namespace MyNamespace                                   // 名前空間：PascalCase
{
    // 列挙体(Enum)
    public enum MyEnum                                  // 列挙体：PascalCase
    {
        Yes,                                            // 列挙値：PascalCase
        No,
    }

    // インターフェース(Interface)
    public interface IMyInterface                       // インターフェース：最初に"I"を付ける + PascalCase
    {
        public void MyInterfaceMethod();                // メソッド：PascalCase
    }

    // 構造体(Struct)
    public struct MyStruct                              // 構造体：PascalCase
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // クラス(Class)
    public class MyClass : MonoBehaviour                // クラス：PascalCase
    {
        // ローカルルール：シリアライズ化するフィールドがある場合はヘッダーを記述する
        // ローカルルール：オブジェクトやクラス等のアタッチグループのヘッダーには"Config"を付ける
        [Header("My Header Config")]                    // ヘッダー：基本的に英語で記述する
        // SerializeField
        // ローカルルール：シリアライズ化するフィールドは変数の順序不要
        // ローカルルール：シリアライズ化するフィールドは一番上に記述する
        [SerializeField] private RigidBody2D _rigidBody2D;  // シリアライズ化するフィールド：_camelCase
        
        // ローカルルール：変数等のグループのヘッダーには"Settings"を付ける
        [Header("My Header Settings")]
        // ローカルルール：その他属性は[SerializeField]以外変数の上の行に記述する
        [Tooltip("ツールチップ")] [Min(0)]                // ツールチップ：日本語で記述可能
        // ローカルルール：初期値はデフォルト値でも記述する
        [SerializeField] private int _myField = 0;
        
        // ローカルルール：snake_case(例：const_variable) ※UPPER_SNAKE_CASEは可読性に劣るのでsnake_caseを使用
        // ローカルルール：初期値はデフォルト値の場合は記述しない
        private const int const_variable = 100;          // constフィールド：snake_case
        private readonly int readonlyVariable = 100;    // readonlyフィールド：camelCase
        private static int StaticVariable;              // staticフィールド：PascalCase
        public int PublicVariable;                      // publicフィールド：PascalCase
        internal int internalVariable;                  // internalフィールド：camelCase
        protected internal int protectedInternalVariable;   // protected internalフィールド：camelCase
        protected int protectedVariable;                // protectedフィールド：camelCase
        // ローカルルール：最初に"_"(アンダースコア・アンダーバー)を付ける　例：_privateVariable
        private float _privateVariable = 0.0f;          // privateフィールド：_camelCase
        // ローカルルール：bool型の変数やメソッド等はis, can, has等を最初に付け加える（例：isGround［地面に着地している］、canJump［ジャンプが出来る］等）
        private bool _hasBool = false;
        
        // デリゲート(Delegate)
        public delegate int Delegate();                 // デリゲート：PascalCase

        // イベント(Event)

        // 列挙体(Enum)

        // インターフェース(Interface)

        // プロパティ(Property)
        public int PublicMyProperty { get; set; }       // publicプロパティ：PascalCase
        private int privateMyProperty { get; set; }     // privateプロパティ：camelCase
        
        // Awakeメソッド(Unityイベント)
        private void Awake()
        {
            // 自身のオブジェクトからコンポーネントを取得する場合はAwakeメソッドで取得する
            var myComponent = GetComponent<MyComponent>();
            
            // var a = 1, b = 2; のように1行にまとめない
            var a = 1;
            var b = 2;
            var sum = Sum(a, b);
        }
        
        // Startメソッド(Unityイベント)
        private void Start()
        {
            // 外部のオブジェクトからコンポーネントを取得する場合はStartメソッドで取得する
            // リーダブルコード：右に長いコードを書かない
            // "."（ドット、ピリオドが１行につき２つまでそれ以上の場合は区切りをつける（あまり改行をしない）
            var player = GameObject.Find("Player").GetComponent<Player>();
            player.PlayerMethod();
            
            // リーダブルコード：ifとelseの両方がある場合は肯定系をif、否定系をelseにする
            // リーダブルコード：== true, == falseは不要
            if (IsGround())
            {
                
            }
            else
            {
                
            }
            
            // リーダブルコード：比較するときは変数を左に、定数を右にする
            if (myField == 1)
            {
                
            }
            
            // リーダブルコード：正しい早期リターン
            // elseを書きたくないからって早期リターンするな
            if (IsGround())
            {
                MyMethod(1);
                return;
            }
            
            MyMethod(2);
        }
        
        // リーダブルコード：bool型は肯定系で返す
        private bool IsGround()
        {
            // リーダブルコード：早期リターン
            // メソッドはできるだけ早く抜ける
            // リーダブルコード：{}(波括弧)は必ず付ける。なお、1行の処理の場合は処理の最初に"{"、最後に"}"を付ける
            if (hasBool) { return false; }
            
            return true;
        }
        
        // FixedUpdateメソッド(Unityイベント)
        private void FixedUpdate() { }
        
        // Updateメソッド(Unityイベント)
        private void Update()
        {
            MyMethod(1);
        }
        
        // メソッド(Method)                               // メソッド：PascalCase
        private void MyMethod(int e)                    // 引数：camelCase
        {
            // 変数の型が明示的にわかる場合はvarを使用する
            var localVariable = "value";                // ローカル変数：camelCase
            int sum = Sum(1, 2);
        }
        
        // 呼び出し元メソッドの下に記述する。なお、複数呼び出し元がある場合は最後の呼び出し元メソッドの下に記述する
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
        
        // 呼び出し元が外部のみにある場合は最後に記述する
        // ローカルルール：publicメソッドはサマリーXMLタグを記述する
        /// <summary>
        /// パブリックメソッド
        /// </summary>
        /// <param name="a">引数</param>
        public void MyPublicMethod(int a) { }

        // 構造体(Struct)

        // クラス(Class)
    }
    
    // シリアライズ化するクラス
    [Serializable]
    public class MySerializableClass { }
}
