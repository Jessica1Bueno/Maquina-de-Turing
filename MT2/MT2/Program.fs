(*Alumno: Jessica Elizabeth Bueno Sánchez
Matricula: 170011
Institución: Universidad Politécnica de San Luis Potosí
Carrera: Ingeniería en Tecnologías de la Información
Materia: Teoría Computacional
Docente: Juan Carlos González Ibarra*)

(*La manera en la que se leen las reglas es la siguiente
["s2";"1";"1";"left";"s2"];
esta en s2, lee un 1, escribe un 1 y va a la izquierda hacia s2*)

open System

open System.Collections.Generic

exception Error of string //error
//función para recorrerla maquina 
let turing_M (estado,blank,rules:list<list<string>>,cinta:list<string>,final,pos) =
    //variables que seran modifficadas en el transcurso de la corrida
    let mutable st=estado//inicializa el estado tomando el valor
    let mutable pos=pos//posición
    let mutable cinta=cinta//cinta
    if cinta.IsEmpty then//si la cinta esta vacia
        cinta<-[blank]//agrega el blanck
    if pos<0 then//si la posición es menor a 0
        pos<-pos+cinta.Length//se toma el valor de la posición mas el tamaño de la cinta
    if pos>=cinta.Length || pos<0 then//si la posicion es mayor o igual  al de la cinta o menor a 0
        raise(Error("Se inicializa mal la posición"))//marca un error en donde se inicializo mal la posición

    //rules = dict(((s0, v0), (v1, dr, s1)) for  (s0, v0, v1, dr, s1) in rules)
    //let dict = new Dictionary<string, string>()
    let mutable aux=true //auxiliar para el while

    while aux do//mientras se a verdad
        printf"%A\t"st//se va a imprimir el estado en el que se encuentra
        for i in 0..cinta.Length-1 do//recorre la cinta
            if i.Equals(pos) then//si i es igual a la posicion 
                printf "[%A] " cinta.[i]//entonces lo encierra en []
            else                            //si no
                printf " %A  " cinta.[i]    //lo imprime como tal
        printfn " "//imprime un salto de linea
        if st.Equals(final)then//si el estado es igual a s12 pone el auxiliar en ffalso para salir
            aux<-false
        

        let mutable direc=" "   //dirección
        let mutable s1=" "
        if direc.Equals("left")then//si la dirección es a la izquierda 
            if pos>0 then           //y si la posicion es mayor a 0
                pos<-pos-1          //recorre a la izquierda restandole 1 a la posición
            else                    //si es el inicio coloca el b que es blank
                 cinta <- [blank] @ cinta   //al inicio
        if direc.Equals("right")then    //si es a la derecha
            pos<-pos+1                  //recorre a la der sumandole uno a la pos
            if pos >= cinta.Length then//si la posicion es mayor al tamaño de la cadena
                cinta <- cinta @ [blank]//le coloca al ffinal un blank
        st=s1                           



       


[<EntryPoint>]
let main argv =
    printfn "División 111/111"
    //reglas de las transiciones que debe seguir
    let rules = [["s1";"1";"1";"right";"s1"];
                ["s1";"/";"/";"right";"s1"];
                ["s1";"b";"=";"left";"s2"];
                ["s2";"1";"1";"left";"s2"];
                ["s2";"/";"/";"right";"s3"];
                ["s3";"x";"x";"right";"s3"];
                ["s3";"=";"=";"right";"s7"];
                ["s3";"1";"x";"left";"s4"];
                ["s4";"1";"1";"left";"s4"];
                ["s4";"/";"/";"left";"s4"];
                ["s4";"x";"x";"left";"s4"];
                ["s4";"D";"D";"right";"s5"];
                ["s4";"b";"b";"right";"s5"];
                ["s5";"1";"D";"right";"s6"];
                ["s6";"1";"1";"right";"s6"];
                ["s6";"/";"/";"right";"s3"];
                ["s7";"1";"1";"right";"s7"];
                ["s7";"b";"1";"left";"s8"];
                ["s8";"1";"1";"left";"s8"];
                ["s8";"=";"=";"left";"s8"];
                ["s8";"x";"1";"left";"s8"];
                ["s8";"/";"/";"left";"s9"];
                ["s9";"1";"1";"right";"s13"];
                ["s9";"D";"D";"right";"s10"];
                ["s10";"1";"1";"right";"s10"];
                ["s10";"=";"=";"right";"s10"];
                ["s10";"/";"/";"right";"s10"];
                ["s10";"b";"B";"right";"s11"];
                ["s11";"b";"b";"right";"s12"];
                ["s13";"1";"1";"right";"s13"];
                ["s13";"=";"=";"right";"s13"];
                ["s13";"/";"/";"right";"s13"];
                ["s13";"b";"B";"right";"s14"];
                ["s14";"b";"1";"right";"s12"];]

    turing_M ("s1","b",rules,["1";"1";"/";"1";"1"],"s12",0)
    0 // return an integer exit code
