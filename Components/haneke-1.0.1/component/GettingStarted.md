# Getting Started with HanekeComponent

![Haneke](https://raw.githubusercontent.com/Haneke/Haneke/master/Assets/github-header.png)

A lightweight zero-config image cache for Xamarin iOS.

Haneke resizes images and caches the result on memory and disk. Everything is done in background, allowing for fast, responsive scrolling. Asking Haneke to load, resize, cache and display an *appropriately sized image* is as simple as:


	ImageView.SetImage(url);


_Really._

##Features

* First-level memory cache using `NSCache`.
* Second-level LRU disk cache using the file system.
* Zero-config `UIImageView` category to use the cache, optimized for `UITableView` and `UICollectionView` cell reuse.
* Asynchronous and synchronous image retrieval.
* Background image resizing and file reading.
* Image decompression.
* Custom image transformations before and after resizing.
* Thread-safe.
* Automatic cache eviction on memory warnings or disk capacity reached.
* Preloading images from the disk cache into memory on startup.

##UIImageView extension

Haneke provides convenience methods for `UIImageView` with optimizations for `UITableView` and `UICollectionView` cell reuse. Images will be resized appropriately and cached in a shared cache.


	// Setting a remote image
	ImageView.SetImage(url);

	// Setting a local image
	ImageView.SetImage(path);

	// Setting an image manually. Requires you to provide a key.
	ImageView.SetImage(image, key);

The above lines take care of:

1. If cached, retrieving an appropriately sized image (based on the `bounds` and `contentMode` of the `UIImageView`) from the memory or disk cache. Disk access is performed in background.
2. If not cached, loading the original image from web/disk/memory and producing an appropriately sized image, both in background. Remote images will be retrieved from the shared `NSURLCache` if available.
3. Setting the image and animating the change if appropriate.
4. Or doing nothing if the `UIImageView` was reused during any of the above steps.
5. Caching the resulting image.
6. If needed, evicting the least recently used images in the cache.


##Cache formats

The cache behavior can be customized by defining cache formats. Each image view has a default format and you can also define your own formats. A format is uniquely identified by its name.

### UIImageView format

Each image view has a default format created on demand. The default format is configured as follows:

* Size matches the `bounds` of the image view.
* Images will be scaled based on the `contentMode` of the the image view.
* Images can be upscaled if they're smaller than the image view.
* High compression quality.
* No preloading.
* Up to 10MB of disk cache.

Modifying this default format is discouraged. Instead, you can set your own custom format like this:

	HNKCacheFormat format = (HNKCacheFormat)HNKCache.SharedCache().Formats["thumbnail"];
            if (format == null)
            {
                format = new HNKCacheFormat("thumbnail")
                    {
                        Size = new SizeF(320, 240),
                        ScaleMode = HNKScaleMode.AspectFill,
                        CompressionQuality = 0.5f,
                        DiskCapacity = 1 * 1024 * 1024,
                        PreloadPolicy = HNKPreloadPolicy.LastSession
                    };
            }
			HanekeImageView.SetCacheFormat(format);


To apply the same custom format to various image views you must use the same format instance. The above example does this by initializing the custom format only if it's not already registered in the shared cache. In the last line, the image view category takes care of registering the format in the shared cache if needed.

### Disk cache

A format can have disk cache by setting the `diskCapacity` property with a value greater than 0. Haneke will take care of evicting the least recently used images of the format from the disk cache when the disk capacity is surpassed.

### Preload policy

When registering a format, Haneke will load none, some or all images cached on disk into the memory cache based on the preload policy of the format. The available preload policies are:

* `PolicyNone`: No images will be preloaded.
* `PolicyLastSession`: Only images from the last session will be preloaded.
* `PolicyAll`: All images will be preloaded.

If an image of the corresponding format is requested before preloading finishes, Haneke will cancel preloading to give priority to the request. To make the most of this feature it's recommended to register formats on startup.

Preloading only applies to formats that have disk cache.

##Requirements

Haneke requires iOS 7.0 or above. 
