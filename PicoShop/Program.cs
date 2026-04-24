using SkiaSharp;


// percorso dell'immagine da cui attingere
Console.WriteLine("");
Console.WriteLine("Specificare il percorso dell'immagine (se la foto è nella cartella basta mettere nome ed estensione)");
Console.Write("* ");
string imagePath = Console.ReadLine()!; 

// Controllo esistena file
if (File.Exists(imagePath) && imagePath != " ")
{
    // Carica il file in un oggetto SKBitmap
    using (var bitmap = SKBitmap.Decode(imagePath))
    {
        Console.WriteLine("");
        Console.WriteLine("*----------------------------------------------------------------------*");
        Console.WriteLine("Scegliere lunghezza e altezza dell'immagine selezionata (in pixel) :");
        Console.WriteLine($"le dimensioni originali sono {bitmap.Width} x {bitmap.Height}");
        Console.Write("Lunghezza X :");
        int lunghezza = Convert.ToInt32(Console.ReadLine());
        Console.Write("Altezza Y :");
        int altezza = Convert.ToInt32(Console.ReadLine());

        // Creiamo un foglio
        var info = new SKImageInfo(lunghezza, altezza);

        using (var surface = SKSurface.Create(info))
        {
            SKCanvas canvas = surface.Canvas;
            canvas.Clear(SKColors.White); // Sfondo bianco

            // adattiamo l'immagine (Sinistra, Alto, Destra, Basso)
            var areaDestinazione = new SKRect(0, 0, lunghezza, altezza); 
                
            // Disegniamo l'immagine
            canvas.DrawBitmap(bitmap, areaDestinazione);
        }
    }
}
else // Stampiano una foto di errore
{
    Console.WriteLine($"Errore: Non riesco a trovare il file '{imagePath}' nella cartella.");
    
    using (var paint = new SKPaint())
    {
        paint.Color = SKColors.Red;
        paint.IsAntialias = true;


        // Creiamo un foglio
        var info = new SKImageInfo(920,790);

        using (var surface = SKSurface.Create(info))
        {
            SKCanvas canvas = surface.Canvas;
            canvas.Clear(SKColors.White); // Sfondo bianco

            // Stile testo
            using (var font = new SKFont(SKTypeface.Default, 40)) 
            {
                canvas.DrawText("Immagine non trovata!", 150, 300, font, paint);
            }
            
            // Salvataggio foto errore
            using (var image = surface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = File.OpenWrite("Errore!.png"))
            {
                data.SaveTo(stream);
            }
            Console.Write("Immagine di errore creata uscita dal programma.");
        }
        return;
    }
}

string titolo1 = @"

        ____ ___ ____ ___                         
__/\__ |  _ \_ _/ ___/ _ \                        
\    / | |_) | | |  | | | |                       
/_  _\ |  __/| | |__| |_| |                       
  \/   |_|  |___\____\___/   _  ___  ____         
                  / ___|| | | |/ _ \|  _ \  __/\__
                  \___ \| |_| | | | | |_) | \    /
                   ___) |  _  | |_| |  __/  /_  _\
                  |____/|_| |_|\___/|_|       \/  

";
string titolo2 = @"
        __  __             __                                        
__/\__ |  \/  | ___ _ __  _\_\_                                      
\    / | |\/| |/ _ \ '_ \| | | |                                     
/_  _\ | |  | |  __/ | | | |_| |                                     
  \/   |_|  |_|\___|_|_|_|\__,_|           _                         
                  |  _ \ ___ | |_ __ _ ___(_) ___  _ __   ___  __/\__
                  | |_) / _ \| __/ _` |_  / |/ _ \| '_ \ / _ \ \    /
                  |  _ < (_) | || (_| |/ /| | (_) | | | |  __/ /_  _\
                  |_| \_\___/ \__\__,_/___|_|\___/|_| |_|\___|   \/  
";
string titolo3 = @"
        __  __             __                  
__/\__ |  \/  | ___ _ __  _\_\_                
\    / | |\/| |/ _ \ '_ \| | | |               
/_  _\ | |  | |  __/ | | | |_| |               
  \/   |_|  |_|\___|_| |_|\__,_|               
                   _____ _ _ _        _        
                  |  ___(_) | |_ _ __(_) __/\__
                  | |_  | | | __| '__| | \    /
                  |  _| | | | |_| |  | | /_  _\
                  |_|   |_|_|\__|_|  |_|   \/   
";
string titolo4 = @"
        __  __             __                                                 
__/\__ |  \/  | ___ _ __  _\_\_                                               
\    / | |\/| |/ _ \ '_ \| | | |                                              
/_  _\ | |  | |  __/ | | | |_| |                                              
  \/   |_|  |_|\___|_| |_|\__,_|        _           _                         
             / ___|___  _ ____   _____ | |_   _ ___(_) ___  _ __   ___  __/\__
            | |   / _ \| '_ \ \ / / _ \| | | | |_  / |/ _ \| '_ \ / _ \ \    /
            | |__| (_) | | | \ V / (_) | | |_| |/ /| | (_) | | | |  __/ /_  _\
             \____\___/|_| |_|\_/ \___/|_|\__,_/___|_|\___/|_| |_|\___|   \/   
";

bool controllo = true;
while (controllo)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(titolo1);
    Console.ResetColor();
    Console.WriteLine("======== Menù ========");
    Console.WriteLine("");
    Console.WriteLine("Scegliere un opzione:");
    Console.WriteLine("0)   Esci");
    Console.WriteLine("1)   Trasposizione");
    Console.WriteLine("2)   Rotazione");
    Console.WriteLine("3)   Scala di Grigi");
    Console.WriteLine("4)   filtri");
    Console.WriteLine("5)   Filtri di convoluzione");
    Console.WriteLine("6)   SpecchiaX");
    Console.WriteLine("7)   SpecchiaY");
    Console.Write("* ");
    int scelta = Convert.ToInt32(Console.ReadLine());

    if(scelta == 0)
    {
        break;
    }
    else if (scelta == 1)
    {
        Trasposizione();
        Console.WriteLine("L'immagine e' stata trasposta"); 
    }
    else if(scelta == 2)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(titolo2);
        Console.ResetColor();
        Console.WriteLine("======== Menù ========");
        Console.WriteLine("");
        Console.WriteLine("Scegliere un opzione di rotazione(senso antiorario):");
        Console.WriteLine("0)   90°");
        Console.WriteLine("1)   180°");
        Console.WriteLine("2)   270°");
        Console.Write("* ");
        int sceltaRotazione = Convert.ToInt32(Console.ReadLine());

        if (sceltaRotazione == 0)
        {
            Rotea90();
            Console.WriteLine("Immagine ruotata di 90°"); 
        }
        else if(sceltaRotazione == 1)
        {
            Rotea180();
            Console.WriteLine("Immagine ruotata di 180°");  
        }
        else if(sceltaRotazione == 2)
        {
            Rotea270();
            Console.WriteLine("Immagine ruotata di 270°");  
        }
    }
    else if (scelta == 3)
    {
        ScalaDiGrigi();
    }
        else if(scelta == 4)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(titolo3);
        Console.ResetColor();
        Console.WriteLine("======== Menù ========");
        Console.WriteLine("");
        Console.WriteLine("Scegliere un filtro colore:");
        Console.WriteLine("0)   Rosso");
        Console.WriteLine("1)   Verde");
        Console.WriteLine("2)   Blu");
        Console.WriteLine("3)   Cremisi");
        Console.WriteLine("4)   Ceruleo");
        Console.WriteLine("5)   Palude");
        Console.Write("* ");
        int sceltaFiltri = Convert.ToInt32(Console.ReadLine());

        if (sceltaFiltri == 0)
        {
            FiltroRosso();
            Console.WriteLine("E' stato applicato un filtro rosso all'immagine"); 
        }
        else if(sceltaFiltri == 1)
        {
            FiltroVerde();
            Console.WriteLine("E' stato applicato un filtro verde all'immagine");  
        }
        else if(sceltaFiltri == 2)
        {
            FiltroBlu();
            Console.WriteLine("E' stato applicato un filtro blu all'immagine"); 
        }
        else if(sceltaFiltri == 3)
        {
            FiltroCremisi();
        }
        else if(sceltaFiltri == 4)
        {
            FiltroCeruleo();
        }
        else if(sceltaFiltri == 5)
        {
            FiltroPalude();
        }
    }

        else if(scelta == 5)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(titolo4);
        Console.ResetColor();
        Console.WriteLine("======== Menù ========");
        Console.WriteLine("");
        Console.WriteLine("Scegliere un filtro di convoluzione:");
        Console.WriteLine("0)   Sharpening");
        Console.WriteLine("1)   Blur");
        Console.WriteLine("2)   Sobel Edge Detection_X");
        Console.WriteLine("3)   Sobel Edge Detection_Y");
        Console.WriteLine("4)   OutlineTotale");
        Console.WriteLine("5)   Emboss");
        Console.Write("* ");
        int sceltaFiltri2 = Convert.ToInt32(Console.ReadLine());

        if (sceltaFiltri2 == 0)
        {
            Sharpening();
            Console.WriteLine("E' stato applicato lo sharpening dell'immagine"); 
        }
        else if(sceltaFiltri2 == 1)
        {
            Blur();
            Console.WriteLine("E' stato applicato il blur dell'immagine");  
        }
        else if(sceltaFiltri2 == 2)
        {
            EdgeDetectionX();
        }
        else if(sceltaFiltri2 == 3)
        {
            EdgeDetectionY();
        }
        else if(sceltaFiltri2 == 4)
        {
            OutlineTotale();
        }
        else if(sceltaFiltri2 == 5)
        {
            Emboss();
        }
    }

    else if (scelta == 6)
    {
        SpecchiaX();
    }
        else if (scelta == 7)   
    {
        SpecchiaY();
    }

    else
    {
        Console.WriteLine("Valore non valido riprovare");
    }
}

void Rotea90()
{    
    // Carico foto in originale e la ruoto in una bitmap con H e L invertite
    using var original = SKBitmap.Decode(imagePath);
    var ruotata = new SKBitmap(original.Height, original.Width);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);

            // La nuova X è (LunghezzaVecchia - 1 - x)
            // La nuova Y è (AltezzaVecchia - 1 - y)
            int nuovaX = y;
            int nuovaY = original.Width - 1 - x;

            // Imposta il pixel nella nuova posizione
            ruotata.SetPixel(nuovaX, nuovaY, colorePixel);
        
        }
            
    }

    using (var image = SKImage.FromBitmap(ruotata))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_ruotata90°.Png"))
    {
        data.SaveTo(stream);
    }

    ruotata.Dispose();// Pulizia risorse estene (tutto ciò che è fuori dal controllo dell'ambiente di esecuzione)
}

void Rotea180()
{    
    // Carico foto in originalein una bitmap con H e L uguali
    using var original = SKBitmap.Decode(imagePath);
    var ruotata = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);

            // La nuova X è (LunghezzaVecchia - 1 - x)
            // La nuova Y è (AltezzaVecchia - 1 - y)
            int nuovaX = original.Width - 1 - x;
            int nuovaY = original.Height -1 - y;

            // Imposta il pixel nella nuova posizione
            ruotata.SetPixel(nuovaX, nuovaY, colorePixel);
        
        }
            
    }

    using (var image = SKImage.FromBitmap(ruotata))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_ruotata180°.Png"))
    {
        data.SaveTo(stream);
    }

    ruotata.Dispose();
}

void Rotea270()
{    
    // Carico foto in originale e la ruoto in una bitmap con H e L invertite
    using var original = SKBitmap.Decode(imagePath);
    var ruotata = new SKBitmap(original.Height, original.Width);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);

            // La nuova X è (AltezzaVecchia - 1 - y)
            // La nuova Y è (x)
            int nuovaX = original.Height - 1 - y;
            int nuovaY = x;

            // Imposta il pixel nella nuova posizione
            ruotata.SetPixel(nuovaX, nuovaY, colorePixel);
        
        }
            
    }

    using (var image = SKImage.FromBitmap(ruotata))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_ruotata270°.Png"))
    {
        data.SaveTo(stream);
    }

    ruotata.Dispose();
}

void Trasposizione()
{    
    // Carico foto in originale e la ruoto in una bitmap con H e L invertite
    using var original = SKBitmap.Decode(imagePath);
    var trasposta = new SKBitmap(original.Height, original.Width);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);

            // La nuova X è (y)
            // La nuova Y è (x)
            int nuovaX = y;
            int nuovaY = x;

            // Imposta il pixel nella nuova posizione
            trasposta.SetPixel(nuovaX, nuovaY, colorePixel);
        
        }
            
    }

    using (var image = SKImage.FromBitmap(trasposta))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_trasposta.Png"))
    {
        data.SaveTo(stream);
    }

    trasposta.Dispose();
}

void ScalaDiGrigi()
{    
    // Carico foto in originalein una bitmap con H e L uguali
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var grigia = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);
            // prendo i valori RGB dell'immagine
            byte r = colorePixel.Red;   // Usiamo i byte perchè L'RGB ha 255 valori
            byte g = colorePixel.Green;
            byte b = colorePixel.Blue;

            // Calcolo media RGB e imposto i nuovi valori la somma fra byte diventa inte in C#
            int media = (r + g + b) / 3;

            // (byte)media == Casting dei dati mette l'intero media in un byte, per definizione la media non sarà più grande di 255 
            SKColor grigio = new SKColor((byte)media, (byte)media, (byte)media);
            grigia.SetPixel(x, y, grigio);    
        }     
    }

    using (var image = SKImage.FromBitmap(grigia))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_scala_di_grigi.Png"))
    {
        data.SaveTo(stream);
    }

    grigia.Dispose();
}

void FiltroPalude()
{    
    // Carico foto in originalein una bitmap con H e L uguali
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var verde = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);
            // prendo i valori RGB dell'immagine
            byte r = colorePixel.Red;   // Usiamo i byte perchè L'RGB ha 255 valori
            byte g = 153; // 60 % di 255
            byte b = colorePixel.Blue;

            SKColor filtro = new SKColor(r, g, b);
            verde.SetPixel(x, y, filtro);    
        }     
    }

    using (var image = SKImage.FromBitmap(verde))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Filtro_Palude.Png"))
    {
        data.SaveTo(stream);
    }

    verde.Dispose();
}

void FiltroCremisi()
{    
     // Carico foto in originalein una bitmap con H e L uguali
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var rosso = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);
            // prendo i valori RGB dell'immagine
            byte r = 153;   // 60 % di 255
            byte g =  colorePixel.Green;
            byte b = colorePixel.Blue;

            SKColor filtro = new SKColor(r, g, b);
            rosso.SetPixel(x, y, filtro);    
        }     
    }

    using (var image = SKImage.FromBitmap(rosso))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Filtro_Cremisi.Png"))
    {
        data.SaveTo(stream);
    }

    rosso.Dispose();
}

void FiltroCeruleo()
{    
     // Carico foto in originalein una bitmap con H e L uguali
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var blu = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);
            // prendo i valori RGB dell'immagine
            byte r =  colorePixel.Red;
            byte g =  colorePixel.Green;
            byte b = 153; // 60 % di 255

            SKColor filtro = new SKColor(r, g, b);
            blu.SetPixel(x, y, filtro);    
        }     
    }

    using (var image = SKImage.FromBitmap(blu))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Filtro_Ceruleo.Png"))
    {
        data.SaveTo(stream);
    }

    blu.Dispose();
}

void FiltroRosso()
{    
     // Carico foto in originalein una bitmap con H e L uguali
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var rosso = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);
            // Modifico
            byte r = colorePixel.Red; // Rimane solo il rosso
            byte g =  0;
            byte b = 0;

            SKColor filtro = new SKColor(r, g, b);
            rosso.SetPixel(x, y, filtro);    
        }     
    }

    using (var image = SKImage.FromBitmap(rosso))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Filtro_Rosso.Png"))
    {
        data.SaveTo(stream);
    }

    rosso.Dispose();
}

void FiltroBlu()
{    
     // Carico foto in originalein una bitmap con H e L uguali
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var blu = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);
            // Modifico i valori RGB
            byte r =  0;
            byte g =  0;
            byte b = colorePixel.Blue; //rimane solo il blu

            SKColor filtro = new SKColor(r, g, b);
            blu.SetPixel(x, y, filtro);    
        }     
    }

    using (var image = SKImage.FromBitmap(blu))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Filtro_Blu.Png"))
    {
        data.SaveTo(stream);
    }

    blu.Dispose();
}

void FiltroVerde()
{    
    // Carico foto in originalein una bitmap con H e L uguali
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var verde = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);
            // Modifico
            byte r = 0;   // Usiamo i byte perchè L'RGB ha 255 valori
            byte g = colorePixel.Green; // Rimane solo il verde
            byte b = 0;

            SKColor filtro = new SKColor(r, g, b);
            verde.SetPixel(x, y, filtro);    
        }     
    }

    using (var image = SKImage.FromBitmap(verde))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Filtro_verde.Png"))
    {
        data.SaveTo(stream);
    }

    verde.Dispose();
}

void Sharpening()
{    
    // Carico foto in originale in una bitmap
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var convoluzione = new SKBitmap(original.Width, original.Height);

    //i = righe, j = colonne
    int[,] kernel =
    {
        {-1, -1, -1},
        {-1, 9, -1},
        {-1, -1, -1}
    };
    
    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){

            int sumR = 0;
            int sumG = 0;
            int sumB = 0;            
            
            // Facciamo partire i cicli del kernel da -1 fino a +1 compreso
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {

                    int pixelX = x + i;
                    int pixelY = y + j;
                    
                    //controllo dei bordi
                    if (pixelX >= 0 && pixelX < original.Width && pixelY >= 0 && pixelY < original.Height)
                    {
                        SKColor pixelColor = original.GetPixel(pixelX, pixelY);
            
                        // Quando i=-1, leggerà 0. Quando i=0, leggerà 1. Quando i=1, leggerà 2.
                        int k = kernel[j + 1, i + 1];

                        sumR += pixelColor.Red * k;
                        sumG += pixelColor.Green * k;
                        sumB += pixelColor.Blue * k;
                    }
                }
            }

            // Blocchiamo i valori nel range corretto [0 - 255]
            byte finalR = (byte)Math.Clamp(sumR, 0, 255);
            byte finalG = (byte)Math.Clamp(sumG, 0, 255);
            byte finalB = (byte)Math.Clamp(sumB, 0, 255);

            convoluzione.SetPixel(x, y, new SKColor(finalR, finalG, finalB));           

        }     
    }

    using (var image = SKImage.FromBitmap(convoluzione))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Sharpening.Png"))
    {
        data.SaveTo(stream);
    }

    convoluzione.Dispose();
}

void Blur()
{    
    // Carico foto in originale e la ruoto in una bitmap
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var convoluzione = new SKBitmap(original.Width, original.Height);

    //i = righe, j = colonne
    int[,] kernel =
    {
        {1, 2, 1,},
        {2, 4, 2,},
        {1, 2, 1,},
    };
    
        for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){

            int sumR = 0;
            int sumG = 0;
            int sumB = 0;            
            int pesoTotale = 0;

            // Facciamo partire i cicli del kernel da -1 fino a +1 compreso
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {

                    int pixelX = x + i;
                    int pixelY = y + j;
                    
                    //controllo dei bordi
                    if (pixelX >= 0 && pixelX < original.Width && pixelY >= 0 && pixelY < original.Height)
                    {
                        SKColor pixelColor = original.GetPixel(pixelX, pixelY);
            
                        // Quando i=-1, leggerà 0. Quando i=0, leggerà 1. Quando i=1, leggerà 2.
                        int k = kernel[j + 1, i + 1];

                        sumR += pixelColor.Red * k;
                        sumG += pixelColor.Green * k;
                        sumB += pixelColor.Blue * k;

                        pesoTotale += k;
                    }
                }
            }

            if (pesoTotale == 0) pesoTotale = 1; // evitiamo le divisioni per 0

            // Dividiamo per la somma totale dei pesi
            sumR = sumR / pesoTotale;
            sumG = sumG / pesoTotale;
            sumB = sumB / pesoTotale;

            // Blocchiamo i valori nel range corretto (0 - 255)
            byte finalR = (byte)Math.Clamp(sumR, 0, 255);
            byte finalG = (byte)Math.Clamp(sumG, 0, 255);
            byte finalB = (byte)Math.Clamp(sumB, 0, 255);

            convoluzione.SetPixel(x, y, new SKColor(finalR, finalG, finalB));           

        }     
    }

    using (var image = SKImage.FromBitmap(convoluzione))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Blur.Png"))
    {
        data.SaveTo(stream);
    }

    convoluzione.Dispose();
}

void SpecchiaX()
{    
    // Carico foto in originale e in una bitmap
    using var original = SKBitmap.Decode(imagePath);
    var specchiata = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);

            int nuovaX = original.Width - 1 - x;
            int nuovaY = y;

            // Imposta il pixel nella nuova posizione
            specchiata.SetPixel(nuovaX, nuovaY, colorePixel);
        
        }
            
    }

    using (var image = SKImage.FromBitmap(specchiata))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_specchiataX°.Png"))
    {
        data.SaveTo(stream);
    }

    specchiata.Dispose();
}

void SpecchiaY()
{    
    // Carico foto in originale e in una bitmap
    using var original = SKBitmap.Decode(imagePath);
    var specchiata = new SKBitmap(original.Width, original.Height);

    for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){
            
            SKColor colorePixel = original.GetPixel(x, y);

            int nuovaX = x;
            int nuovaY = original.Height - 1 - y;;

            // Imposta il pixel nella nuova posizione
            specchiata.SetPixel(nuovaX, nuovaY, colorePixel);
        
        }
            
    }

    using (var image = SKImage.FromBitmap(specchiata))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_specchiataY°.Png"))
    {
        data.SaveTo(stream);
    }

    specchiata.Dispose();
}

void EdgeDetectionX()
{    
    // Carico foto in originale in una bitmap
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var convoluzione = new SKBitmap(original.Width, original.Height);

    //i = righe, j = colonne
    int[,] kernel =
    {
        {1, 0, -1,},
        {2, 0, -2,},
        {1, 0, -1,},
    };
    
        for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){

            int sumR = 0;
            int sumG = 0;
            int sumB = 0;            
            int pesoTotale = 0;

            // Facciamo partire i cicli del kernel da -1 fino a +1 compreso
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {

                    int pixelX = x + i;
                    int pixelY = y + j;
                    
                    //controllo dei bordi
                    if (pixelX >= 0 && pixelX < original.Width && pixelY >= 0 && pixelY < original.Height)
                    {
                        SKColor pixelColor = original.GetPixel(pixelX, pixelY);
            
                        // Quando i=-1, leggerà 0. Quando i=0, leggerà 1. Quando i=1, leggerà 2.
                        int k = kernel[j + 1, i + 1];

                        sumR += pixelColor.Red * k;
                        sumG += pixelColor.Green * k;
                        sumB += pixelColor.Blue * k;

                        pesoTotale += k;
                    }
                }
            }

            if (pesoTotale == 0) pesoTotale = 1; // evitiamo le divisioni per 0

            // Dividiamo per la somma totale dei pesi
            sumR = sumR / pesoTotale;
            sumG = sumG / pesoTotale;
            sumB = sumB / pesoTotale;

            // Blocchiamo i valori nel range corretto [0 - 255]
            byte finalR = (byte)Math.Clamp(sumR, 0, 255);
            byte finalG = (byte)Math.Clamp(sumG, 0, 255);
            byte finalB = (byte)Math.Clamp(sumB, 0, 255);

            convoluzione.SetPixel(x, y, new SKColor(finalR, finalG, finalB));           

        }     
    }

    using (var image = SKImage.FromBitmap(convoluzione))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Sobel_EdgeX.Png"))
    {
        data.SaveTo(stream);
    }

    convoluzione.Dispose();
}

void EdgeDetectionY()
{    
    // Carico foto in originale in una bitmap
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var convoluzione = new SKBitmap(original.Width, original.Height);

    //i = righe, j = colonne
    int[,] kernel =
    {
        // lo stesso di prima solo girato
        {1, 2, 1,},
        {0, 0, 0,},
        {-1, -2, -1,},
    };
    
        for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){

            int sumR = 0;
            int sumG = 0;
            int sumB = 0;            
            int pesoTotale = 0;

            // Facciamo partire i cicli del kernel da -1 fino a +1 compreso
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {

                    int pixelX = x + i;
                    int pixelY = y + j;
                    
                    //controllo dei bordi
                    if (pixelX >= 0 && pixelX < original.Width && pixelY >= 0 && pixelY < original.Height)
                    {
                        SKColor pixelColor = original.GetPixel(pixelX, pixelY);
            
                        // Quando i=-1, leggerà 0. Quando i=0, leggerà 1. Quando i=1, leggerà 2.
                        int k = kernel[j + 1, i + 1];

                        sumR += pixelColor.Red * k;
                        sumG += pixelColor.Green * k;
                        sumB += pixelColor.Blue * k;

                        pesoTotale += k;
                    }
                }
            }

            if (pesoTotale == 0) pesoTotale = 1; // evitiamo le divisioni per 0

            // Dividiamo per la somma totale dei pesi
            sumR = sumR / pesoTotale;
            sumG = sumG / pesoTotale;
            sumB = sumB / pesoTotale;

            // Blocchiamo i valori nel range corretto [0 - 255]
            byte finalR = (byte)Math.Clamp(sumR, 0, 255);
            byte finalG = (byte)Math.Clamp(sumG, 0, 255);
            byte finalB = (byte)Math.Clamp(sumB, 0, 255);

            convoluzione.SetPixel(x, y, new SKColor(finalR, finalG, finalB));           

        }     
    }

    using (var image = SKImage.FromBitmap(convoluzione))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Sobel_EdgeY.Png"))
    {
        data.SaveTo(stream);
    }

    convoluzione.Dispose();
}

void OutlineTotale()
{    
    // Carico foto in originale in una bitmap
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var convoluzione = new SKBitmap(original.Width, original.Height);

    //i = righe, j = colonne
    int[,] kernel =
    {
        //trasfomr le zone uniformi in nero e i bordi in bianco
        {-1, -1, -1,},
        {-1, 8, -1,},
        {-1, -1, -1,},
    };
    
        for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){

            int sumR = 0;
            int sumG = 0;
            int sumB = 0;            

            // Facciamo partire i cicli del kernel da -1 fino a +1 compreso
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {

                    int pixelX = x + i;
                    int pixelY = y + j;
                    
                    //controllo dei bordi
                    if (pixelX >= 0 && pixelX < original.Width && pixelY >= 0 && pixelY < original.Height)
                    {
                        SKColor pixelColor = original.GetPixel(pixelX, pixelY);
            
                        // Quando i=-1, leggerà 0. Quando i=0, leggerà 1. Quando i=1, leggerà 2.
                        int k = kernel[j + 1, i + 1];

                        sumR += pixelColor.Red * k;
                        sumG += pixelColor.Green * k;
                        sumB += pixelColor.Blue * k;
                    }
                }
            }

            //Niente divisione per peso perche il kernerl vale 0

            // Blocchiamo i valori nel range corretto [0 - 255]
            byte finalR = (byte)Math.Clamp(sumR, 0, 255);
            byte finalG = (byte)Math.Clamp(sumG, 0, 255);
            byte finalB = (byte)Math.Clamp(sumB, 0, 255);

            convoluzione.SetPixel(x, y, new SKColor(finalR, finalG, finalB));           

        }     
    }

    using (var image = SKImage.FromBitmap(convoluzione))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Outline.Png"))
    {
        data.SaveTo(stream);
    }

    convoluzione.Dispose();
}

void Emboss()
{    
    // Carico foto in originale in una bitmap
    using var original = SKBitmap.Decode(imagePath);
    //copio in una nuova bitmap
    var convoluzione = new SKBitmap(original.Width, original.Height);

    //i = righe, j = colonne
    int[,] kernel =
    {
        // lo stesso di prima solo girato
        {-2, -1, 0,},
        {-1, 1, 1,},
        {0, 1, 2,},
    };
    
        for(int y = 0; y < original.Height; y++){
        
        for(int x = 0; x < original.Width; x++){

            int sumR = 0;
            int sumG = 0;
            int sumB = 0;            
            int pesoTotale = 0;

            // Facciamo partire i cicli del kernel da -1 fino a +1 compreso
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {

                    int pixelX = x + i;
                    int pixelY = y + j;
                    
                    //controllo dei bordi
                    if (pixelX >= 0 && pixelX < original.Width && pixelY >= 0 && pixelY < original.Height)
                    {
                        SKColor pixelColor = original.GetPixel(pixelX, pixelY);
            
                        // Quando i=-1, leggerà 0. Quando i=0, leggerà 1. Quando i=1, leggerà 2.
                        int k = kernel[j + 1, i + 1];

                        sumR += pixelColor.Red * k;
                        sumG += pixelColor.Green * k;
                        sumB += pixelColor.Blue * k;

                        pesoTotale += k;
                    }
                }
            }

            if (pesoTotale == 0) pesoTotale = 1; // evitiamo le divisioni per 0

            // Dividiamo per la somma totale dei pesi
            sumR = sumR / pesoTotale;
            sumG = sumG / pesoTotale;
            sumB = sumB / pesoTotale;

            // Blocchiamo i valori nel range corretto [0 - 255]
            byte finalR = (byte)Math.Clamp(sumR, 0, 255);
            byte finalG = (byte)Math.Clamp(sumG, 0, 255);
            byte finalB = (byte)Math.Clamp(sumB, 0, 255);

            convoluzione.SetPixel(x, y, new SKColor(finalR, finalG, finalB));           

        }     
    }

    using (var image = SKImage.FromBitmap(convoluzione))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
    using (var stream = File.OpenWrite("Foto_Emboss.Png"))
    {
        data.SaveTo(stream);
    }

    convoluzione.Dispose();
}