# CSharpLearning
В файле содержится 1 проект, с несколькими реализованными для практки языка классами. Пока что в нем присутствуют классы: 
  1) [Complex](Practice/Practice/ComplexNumbersSimpleCalc.cs):
      Разработать класс представляющий комплексное число. Класс должен содержать два свойства для представления вещестенной (double) и мнимой части (double).
    Сделать так чтобы создать экземпляр класса без передачи соответствующих аргументов было невозможно. Создать два метода, реализующих сложение и вычитание
    двух комплексных чисел. Чтобы сложить два комплексных числа необходимо по отдельности сложить их вещественные и мнимые части. То есть, предположим,
    что мы имеет два комплексных числа. У первого вещественная часть равна 1, мнимая 2. У второго вещественная часть равна 3, мнимая 1. Результатам будет комплексное число, где вещественная часть
    равна 1+3=4, а мнимая равна 2 + 1 = 3. Операция вычитания работает по тому же принципу, что и сложение (ну, только вычитание). API спроектировать таким образом,
    чтобы клиентский код мог написать следующий код:
    
    Complex c1 = new Complex(1, 1);
    Complex c2 = new Complex(1, 2);

    Complex result = c1.Plus(c2);
    
  2) [GuessNumber](Practice/Practice/GuessNumber/GuessNumber.cs): 
      Разработать игру "угадай число". Смысл игры. Один из игроков загадывает число от 0 до 100 (по умолчанию), а второй пытается угадать за лимитированное число
    попыток (5 по умолчанию). Когда второй игрок делает предположение о загаданном числе, первый игрок сообщает о том угадано ли число, меньше ли оно загаданного,
    или больше. Если угадано - игра завершена. Если меньше или больше загаданного, то второй игрок сужает область поиска и продолжает пытаться угадывать.
    Так происходит до тех пор пока либо число не угадано, либо исчерпано кол-во попыток. Загадывать может как человек, так и машина. Соответственно и угадывать
    может как человек, так и машина. Это значит, что надо реализовать два режима игры: когда загадывает машина и когда загадывает человек. Если загадывает человек,
    а угадывает машина, то нужно сделать так, чтобы машина пыталсь угадать число, используя алгоритм бинарного поиска. Пример бинарного поиска загаданного числа:
    загадано число 18, при условии, что число загадывалось в диапазоне от 0 до 100. Игрок каждый раз берёт середину, т.е. на первой попытке предполагает число 50.
    Первый игрок говорит, что загаданное число меньше. Значит число лежит между 0 и 50. Тогда второй игрок снова делит диапазон на 2 и предполагает 25. Первый игрок
    говорит, что загаднное число меньше. Значит число между 0 и 25. Тогда второй игрок снова делит диапазон на 2 и предполагает 12 (дробную часть мы просто срезаем).
    Первый игрок говорит, что загаданное число больше. Значит число лежит в диапазоне между 12 и 25. Второй игрок делить диапазон на два и предполагает 18. Первый
    игрок говорит, что число угадано. Игра завершена. На каждой попытке , благодаря так стратегии, диапазон поиска сужается в два раза. Это и есть суть
    бинарного поиска. В конце игры выводится информация о том достигнута ли победа или нет. Конечно же, будет необходимо реализовать диалог между игроками.
    
   3) [TicTacToe](Practice/Practice/TicTacToe.cs):
      Попробуйте реализовать игру в крестики-нолики размером 3х3 - самые что ни наесть обыкновенные. Сделайте метод, который выводит на каждом ходу текущее
      положение с линейками, крестиками и ноликами (используйте буквы X и O в качестве крестиков и ноликов) - так игрокам будет удобнее ориентироваться. Также вам
      понадобится реализовать способ проверки наличия выигрышной комбинации. Подсказа: договоримся, что клетки поля будут пронумерованы от 1 до 9 и пользователи
      будут вводить индекс поля, чтобы поставить там крестик или нолик. Для упрощения - тот кто ходит первым - ставит крестик.
  
