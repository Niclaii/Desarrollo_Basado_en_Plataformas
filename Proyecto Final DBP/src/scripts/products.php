<?php
If(!empty($_POST)){
    $serverName = "";
    $connectionInfo = array("Database"=> "tiendalacteos");
    $conn = sqlsrv_connect($serverName,$connectionInfo);
    $Nombre=$_POST['nombre'];
    $Correo=$_POST['correo'];
    $Contraseña=$_POST['contraseña'];
    $insertar="INSERT into usuarios(Nombre,Correo,Contraseña)values('$Nombre','$Correo','$Contraseña')";
    $recurso = sqlsrv_prepare($conn,$insertar);
}

if (sqlsrv_excecute($recurso)){
    echo"agregado correctamente";
}
else{
        echo"no Agregado";
}


$productos = [
    [
        'nombre' => 'Queso Fresco',
        'precio' => 10.99,
        'imagen' => 'producto1.jpg',
        'descripcion' => 'Queso fresco y delicioso',
    ],
    [
        'nombre' => 'Queso Mozzarella',
        'precio' => 12.99,
        'imagen' => 'producto2.jpg',
        'descripcion' => 'Queso mozzarella de alta calidad',
    ],
];

echo json_encode($productos);
?>
