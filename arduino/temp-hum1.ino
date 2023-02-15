#include <DHT.h>
#include <DHT_U.h>

int sensor = 2;
int temp = 0;
int hum = 0;

DHT dht (sensor, DHT11);

///////////////////////////

int Trigger = 3;
int Echo = 4;
int nivel;

void setup() {
  Serial.begin(9600);
  dht.begin();

  pinMode(Trigger, OUTPUT);
  pinMode(Echo, INPUT); 
  digitalWrite(Trigger, LOW);
}

void loop() {
  /////////////////////

  hum = dht.readHumidity();
  temp = dht.readTemperature();

  Serial.print(temp);
  Serial.print(' ');
  Serial.println(hum);


  
  delay(1000);
}

void sensor_temp_hum(){
  hum = dht.readHumidity();
  temp = dht.readTemperature();

  Serial.println("humedad");
  Serial.println(hum);
  Serial.println("temperatura");
  Serial.println(temp);
}
void ultrasonido(){
  long t; //timepo que demora en llegar el eco
  long d; //distancia en centimetros

  digitalWrite(Trigger, HIGH);
  delayMicroseconds(10);          //Enviamos un pulso de 10us
  digitalWrite(Trigger, LOW);
  
  t = pulseIn(Echo, HIGH); //obtenemos el ancho del pulso
  d = t/59;             //escalamos el tiempo a una distancia en cm
  
  Serial.print("Distancia: ");
  Serial.print(d);      //Enviamos serialmente el valor de la distancia
  Serial.print("cm");
  Serial.println();
}
