# Документация по первому заданию
## [Готовый проект PHP](https://shumilo17.thkit.ee/project/shumilo_project/)
## Задание
+ Создать XML файл в который будет 2 или 3 логичиских диапазона.
+ Файл должен содержать следующие поля :
  + id
  + nimi
  + sugu
  + emakeelne nimi
  + võõrkeelne nimi
+ Сделать вывод таблицы на HTML с использованием : 
  + PHP
  + XSLT
+ Выдумать минимум 3 свои функции : 
  + Показывать только мужское или женское имя
  + Вывод 1 значения с базы данных
  + Поиск по родному имени

## XML файл
```
<?xml version="1.0" encoding="utf-8" ?>
<nimed>
  <nimi id="1">
    <sugu>Mees</sugu>
    <emakeelne>Artur</emakeelne>
    <vorkkeelne>Arthur</vorkkeelne>
  </nimi>
  
  <nimi id="2">
    <sugu>Mees</sugu>
    <emakeelne>Vassili</emakeelne>
    <vorkkeelne>Vasiliy</vorkkeelne>
  </nimi>

  <nimi id="3">
    <sugu>Mees</sugu>
    <emakeelne>Dmitri</emakeelne>
    <vorkkeelne>Dmitriy</vorkkeelne>
  </nimi>

  <nimi id="4">
    <sugu>Naine</sugu>
    <emakeelne>Anna</emakeelne>
    <vorkkeelne>Anya</vorkkeelne>
  </nimi>

  <nimi id="5">
    <sugu>Naine</sugu>
    <emakeelne>Veronica</emakeelne>
    <vorkkeelne>Veronika</vorkkeelne>
  </nimi>

</nimed>
```

## Документация кода PHP
Для дизайна странице я использовал Bootstrap 4 и FontAwesome 4.7
+ Bootstrap 4 :  отвечает за стили страницы
+ FontAwesome 4.7 : отвечает за иконки на странице
 ### В самый верх кода необходима вставить частичку PHP кода для запроса XML файла
 ```
  $xml = simplexml_load_file("autocompleter.xml");
 ```
 
 ### Вывод данных из XML файла при помощи PHP кода в таблицу
```
   <table class="table table-striped">
          <thead>
            <tr>
             <th scope="col">Emakeelne nimi</th>
             <th scope="col">Võõrkeelne nimi</th>
             <th scope="col">Sugu</th>
            </tr>
         </thead>
        <tbody>
          <?php     
           foreach($xml->nimi as $nimed) { // Цикл который работает пока значения в $xml не закончатся 
               echo '<tr>';
               echo '<td>'.$nimed->emakeelne.'</td>';
               echo '<td>'.$nimed->vorkkeelne.'</td>';
               echo '<td>'.$nimed->sugu.'</td>';
               echo '</tr>';
           }
          ?>
       </tbody>
    </table>
```
### Показывать только мужские или женские имена
#### Ссылки, которые передают значения для вывода
```

            <div class="col-6">
                <hr>
                <a href="index.php?x=mehed"><h3>Ainult Mehed</h3></a>
            </div>
            <div class="col-6">
                <hr>
                <a href="index.php?x=naised"><h3>Ainult Naised</h3></a>
            </div>
```
#### PHP код,который принимает эти значения и обрабатывает
```
if(isset($_GET['x'])){
    switch ($_GET['x']) {
        case 'mehed':
            $form = "Mees";
            break;
        case 'naised':
            $form = "Naine";
    }
}
```
#### Вывод самой таблицы 
```
   foreach($xml->nimi as $nimed) {
     if($nimed->sugu == $form){

        echo '<tr>';
        echo '<td>'.$nimed->emakeelne.'</td>';
        echo '<td>'.$nimed->vorkkeelne.'</td>';
        echo '<td>'.$nimed->sugu.'</td>';
        echo '</tr>';
     }

   }
```
### Поиск по родному имени в таблице
#### Форма, в которой есть поля для ввода букв / имени , которое пользователь хочет найти в базе данных, а так же в ней выводиться кол-во найденных имен по запросу пользователя
```
<form action="index.php" id="poisk" enctype="multipart/form-data" autocomplete="off">
 <input type='hidden' name='poisk'>
   <div class="form-group row">
     <label for="colFormLabelLg" class="col-sm-2 col-form-label col-form-label-lg">Emakeelne Nimi</label>
   <div class="col-auto">
   <input type="text" class="form-control form-control-lg" id="nimi" name="nimi" placeholder="Artur">
   </div>
     <div class="col-auto">
      <button type="submit" class="btn btn-primary mb-2">Otsi Nimi</button>
     </div>
   <div class="col-auto"><h5>
   <?php
        if(isset($_REQUEST['poisk'])){
        $inimesed = poisk();
      $leidnud = 0;
      foreach($inimesed as $nimed) {
        $leidnud = $leidnud +1;
        }
      echo "On leidnud ainult : ".$leidnud." inimesi";
      }
   ?>
    </h5><
    /div>
     </div>
</form>
```
#### Функция Поиска, которая ищет в XML файле значения,которые ввел пользователь и выводит их списком
```
function poisk(){

    $result = array();
    $poisk = $_REQUEST['nimi'];
    $xml = simplexml_load_file("autocompleter.xml");

    foreach($xml->nimi as $nimed){

        if(substr(strtolower($nimed -> emakeelne),0,strlen($poisk)) == strtolower($poisk))
            array_push($result,$nimed);

        /*else if(substr(strtolower($arvuti -> graphicscard -> card),0,strlen($query)) == strtolower($query))
            array_push($result,$arvuti);*/
    }
    return $result;
}
```
#### Таблица, которая выводит данные с списка $result
```
<table class="table table-striped">
  <thead>
   <tr>
      <th scope="col">Emakeelne nimi</th>
        <th scope="col">Võõrkeelne nimi</th>
          <th scope="col">Sugu</th>
  </tr>
  </thead>
  <tbody>
  <?php
  if(isset($_REQUEST['poisk'])){
    $inimesed = poisk();
          $leidnud = 0;
    foreach($inimesed as $nimed) {
      echo '<tr>'; 
        echo '<td>'.$nimed->emakeelne.'</td>';
        echo '<td>'.$nimed->vorkkeelne.'</td>';
        echo '<td>'.$nimed->sugu.'</td>';
      echo '</tr>';

     }
     }

    ?>
 </tbody>
  </table>
```
## Документация кода XSLT

### Функция №1
#### Вывод первой буквы с первого имени в XML файле :
nimi[1] - выбирает толкьо первое имя
, 1 , 1 - только первую букву
```
<xsl:value-of select="substring(/nimed/nimi[1]/emakeelne, 1, 1)"/>
```
### Функция №2
#### Количество букв в первом имени:
```
<xsl:value-of select="string-length(/nimed/nimi[1]/emakeelne)"/>
```
### Функция №3
####  Количество данных в XML :
```
<xsl:value-of select="count(/nimed/nimi)"/>
```
### Документация кода ASPX
##### В head у меня находятся ссылки на Bootstrap и Awesome Icons
```
<head runat="server">
    <title>Задание N1</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
```
##### В body находится контейнер, который содержит в себе форму для работы с XSLT файлом и вывод данных в таблицу
```
<body>
    <div class="container">
        <div class="row">
             <div class="col-12">
                <h1 style="text-align: center;"><i class="fa fa-diamond" aria-hidden="true"></i>AutoCompleter</h1>
            </div>
            <div class="col-12">
                <hr />
              <h1>Вывод Таблицы</h1>
                <form id="form1" runat="server">
                  <div>
                    <div>
                     <asp:Xml ID="xml2" runat="server"
                        DocumentSource="~/autocomplt.xml"
                        TransformSource="~/autocompleter.xslt"/>
                    </div>
                  </div>
                </form>
            </div>
        </div>
    </div>
</body>
```
# Документация по второму заданию
## Задание
Создать веб страницу используя ASP NET MVC Web API. На данной веб-странице пользователи могут зарегистрироваться и авторизироваться. У пользователей должно быть 3 роли, такие как :
 + Анонимный пользователь ( не зарегистрированный ) 
 + Юзер ( зарегистрированный)
 + Администратор <br />
Обычный Юзер должен иметь возможность добавлять(в моем случаи я сделал,чтобы он предлагал) новые имена,просматривать список всех предложенных имен, которые были отклонены/приняты или же в ожидании. Так же у него есть возможность сменить свой пароль. У администратора должна быть возможность на принятии предложенных имен, а так же отклонение их, на редактировании уже одобренных или же отклоненных имен. Так же таблица со всеми именами.
## Что получилось
### Аноним
Анонимный пользователь может смотреть ранее добавленные имена на главной странице , а так же зарегистрироваться на веб-странице 
### Пользователь
Зарегистрированный пользователь может в своём профиле добавить новое имя на рассмотрение, после чего имя отоброзиться у него в таблице. Если же администратор одобрит его имя,то оно будет гореть зеленым цветом,если же не одобрит - то красным. Так же есть возможность смена пароля. 
### Администратор
У администратора в личном профиле есть таблица с предложенными именами, которые он должен рассмотреть и принять выбор, одобрить их, или же отклонить, если же администратор одобрит его, то имя добавиться в таблицц на главной странице, и все пользователи смогут его увидеть. Так же у администратора есть права на редактирование уже добавленных / отклоненных имен , так же есть возможность в любой момент убрать любое имя из таблицы или же вернуть его обратно
## Сценарий
### Пользователь
#### Анонимный пользователь зашел на сайт, для того чтобы посмотреть, как пишется его имя на иностранном языке. После того, как он зашел на главную страницу он видит следующие : 
![index](https://i.imgur.com/WbXLmh6.png)
#### Допустим пользователь не нашёл своего имени и он хочет добавить его на веб-страницу, для этого он переходит на страницу регистрации.
![gotoregister](https://i.imgur.com/3zWfJou.png)
#### Далее ему необходимо заполнить все поля.
![gotoregister](https://i.imgur.com/b1y4cjz.png)
#### После успешной регистрации его перенабрасывает на главную страницу. Чтобы добавить новое имя необходимо зайти в свой профиль.
![gotoregister](https://i.imgur.com/AXWYEB1.png)
#### Заполняем необходимые поля, для того чтобы отправить имя на проверку администратору. 
![gotoregister](https://i.imgur.com/5jMvwer.png)
#### Пока имя находится в ожидании, оно будет отображатся таким цветом : 
![gotoregister](https://i.imgur.com/uIiKeBX.png)
### Администратор
#### Посл того, как администратор авторизировался под себя , он заходит в свой профиль.
![gotoregister](https://i.imgur.com/JE6wv77.png)
#### Далее он прокручивает страницу до панели администратора,выглядит она так : 
![gotoregister](https://i.imgur.com/rwepRjA.png)
#### Далеее администратору надо проверить имя, отправленое пользователем, если оно удолетворяет требованиям, то он принимает.
![gotoregister](https://i.imgur.com/Ztl3vtJ.png)
#### После того, как приняли имя, оно отобразиться в таблице и будет зеленого цвета
![gotoregister](https://i.imgur.com/kqU9oHx.png)
#### Если же имя отконили, то оно отобразиться в таблице красным цветом.
![gotoregister](https://i.imgur.com/sqX4TKq.png)
