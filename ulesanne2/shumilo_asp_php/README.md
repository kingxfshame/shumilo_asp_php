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

## Документация кода PHP
Для дизайна страницы я использовал Bootstrap 4 и FontAwesome 4.7
+ Bootstrap 4 :  отвечает за стили страницы
+ FontAwesome 4.7 : отвечает за иконки на страницы

 ### Вывод Таблицы
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
#### Ссылки,которые передают значения для вывода
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
#### Форма,в которой есть поля для ввода букв / имени ,которое пользователь хочет найти в базе данных,а так же в ней выводиться кол-во найденных имен по запросу пользователя
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
#### Функция Поиска,которая ищет в XML файле значения,которые ввел пользователь и выводит их списком
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
#### Таблица,которая ввыодит данные с списка $result
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
