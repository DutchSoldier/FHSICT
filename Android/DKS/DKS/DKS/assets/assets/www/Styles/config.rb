# Get the directory that this configuration file exists in
dir = File.dirname(__FILE__)

# Points to the images directory used by the Sencha Touch theme
#images_dir = File.join(dir, '..', 'core','sencha','resources','themes', 'images', 'default')

# Load the sencha-touch framework automatically.
load File.join(dir, '..', 'themes')

# Compass configurations
sass_path    = dir
css_path     = File.join(dir, "..", "css-debug")
environment  = :development
output_style = :expanded