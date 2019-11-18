<?php 
    $xml = simplexml_load_file("autocompleter.xml");
    $form = "Mees";

if(isset($_GET['x'])){
    switch ($_GET['x']) {
        case 'mehed':
            $form = "Mees";
            break;
        case 'naised':
            $form = "Naine";
    }
}
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
?>
<DOCTYPE html>
<html lang="ee">
<head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <title>AutoCompleter</title>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <h1 style="text-align: center;"><i class="fa fa-diamond" aria-hidden="true"></i>AutoCompleter</h1>
            </div>

            <div class="col-12">
                <hr>
            <h3 style="margin-left:30vh;">Kõik Nimed XML failis</h3>
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
                  foreach($xml->nimi as $nimed) {
                        echo '<tr>';
                        echo '<td>'.$nimed->emakeelne.'</td>';
                        echo '<td>'.$nimed->vorkkeelne.'</td>';
                        echo '<td>'.$nimed->sugu.'</td>';
                        echo '</tr>';
                    }
                  ?>
              </tbody>
            </table>
            </div>

            <div class="col-6">
                <hr>
                <a href="index.php?x=mehed"><h3>Ainult Mehed</h3></a>
            </div>
            <div class="col-6">
                <hr>
                <a href="index.php?x=naised"><h3>Ainult Naised</h3></a>
            </div>
            <div class="col-12">

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
                    foreach($xml->nimi as $nimed) {
                        if($nimed->sugu == $form){

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
            </div>
            <div class="col-12">
                <hr>
            </div>
            <div class="col-12">
                <h3>Esimene nimi XML failis: <?php echo $xml->nimi->emakeelne ?></h3>
            </div>
            <div class="col-12">
                <hr>
                <div class="card">
                    <div class="card-header">
                        Otsi
                    </div>
                    <div class="card-body">
                        <h5 class="card-title">Otsi Emakeelne nime järgi:</h5>
                        <p class="card-text">
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
                                <div class="col-auto"><h5><?php
                                        if(isset($_REQUEST['poisk'])){
                                            $inimesed = poisk();
                                            $leidnud = 0;
                                            foreach($inimesed as $nimed) {
                                                $leidnud = $leidnud +1;

                                            }
                                            echo "On leidnud ainult : ".$leidnud." inimesi";
                                        }



                                        ?></h5></div>
                            </div>
                        </form>
                        </p>
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
                                    $leidnud = $leidnud +1;

                                }
                            }

                            ?>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</body>
</html>