<script type="text/javascript">
        var pw;
        var tempImage;
        $(document).ready(

        function pwStart() {


            var 
                btn = document.getElementById('buttonEditImage'),
                target = document.getElementById('PaintWebTarget'),
                loadp = document.createElement('p'),
                timeStart = null;
            pw = new PaintWeb();

            var item = document.createElement('img');
            item.setAttribute("src", "../../Content/486984.JPG");
            item.setAttribute("id", "editImage");
            //document.body.appendChild(item);

            pw.config.guiPlaceholder = target;
            pw.config.imageLoad = item;
            pw.config.configFile = 'config-example.json';


            timeStart = (new Date()).getTime();
            pw.init();

            


        }
        );

        function update() {

            var img = document.createElement('img');
            img.setAttribute("src", "../../Content/336994.JPG");
            pw.imageLoad(img);
        }

        function save() {
            var evId = pw.events.add('imageSave', saveHandler);
            pw.imageSave('image/jpeg');
        }

        function saveHandler(ev) {
            alert("Hello world");
            // Cancel the default action of the event.
            ev.preventDefault();

            tempImage = ev.dataURL;
        }

        function load() {
            var img = document.createElement('img');
            img.setAttribute("src", tempImage);

            pw.imageLoad(img);

        }
   
    </script>