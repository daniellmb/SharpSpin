Recursive `{Content|Text|Article}` Spinner Algorithm
=========

Effortlessly create variations of your text, either for possible SEO benefit or to simply keep things fresh for your users by reducing content redundancy.

> So this SEO copywriter walks into a `{bar | pub}` for a `{drink | beer | cocktail}`.

---

### Features

- Simple consistent spin syntax
- Supports unlimited nested spin choices
- **100% Unit Test Code Coverage**
- Very fast

---

### How to use

```
var spun_text = Spinner.Spin("The {quick|fast} brown fox jumped over the lazy dog.");
```

### Quick Guide to Spinning Syntax

#### Nested Spinning Vs. Flat Spinning
There are 2 types of spinning – flat spinning (Jet format) and nested spinning. Flat spun content only has one level of spinning, while A nested spun format, like The Best Spinner native format, allows you to spin phrases within phrases or multiple levels of spinning.

Sample sentence
> The quick brown fox jumped over the lazy dog.

###Flat Spinning
```
The {quick|fast} brown fox jumped over the lazy dog.
```

###### Example nested spun variations
- The quick brown fox jumped over the lazy dog.
- The fast brown fox jumped over the lazy dog.

###Nested Spinning
```
The {quick {brown|red}|smart} fox jumped over the lazy dog.
```

###### Example nested spun variations
- The quick brown fox jumped over the lazy dog.
- The quick red fox jumped over the lazy dog.
- The smart fox jumped over the lazy dog.

###Complex Nested Spinning
```
{The {quick|fast|speedy} brown fox {jumped|leaped|hopped} {over|right over|over the top of} 
the {lazy|sluggish|care-free|relaxing} dog.|{While|Although} just {taking|having} 
a{| little| quick} {siesta|nap} the dog was {startled|shocked|surprised} by a {quick|fast|speedy} 
{brown|dark brown|brownish} fox that {leaped|jumped} right {over|over the top of} him.}
```

###### Yes, you can do things like this:
```
{a|b{c|d{e|f{g|h{i|j{k|l{m|n{o|p{q|r{s|t{u|v{w|x{y|z}}}}}}}}}}}}}
```

###### Pro Tip
If you use nesting wisely, you get `{a wide variety of|very different}` content.

1. Spin first at the paragraph level. If you divide your content into stand alone paragraphs on the same subject and write enough paragraphs, you can easily make paragraph-based spun content.
2. Then rewrite every sentence of every paragraph 3 times. This is your second spin level within the paragraph level.
3. Third you can spin words within the sentences with synonym replacements (at least every other fourth word).
4. Set a few of the sentences or paragraphs to optional for even more variation.

If you follow this advice, you will get highly different output that will stay readable.

---

### Documentation 

##### Options:
You can use custom section `{}` and option `|` delimeters if you'd like. For example it's possible to do something like this if you prefer:
```
The [quick~fast] brown fox jumped over the lazy dog.
```

##### Methods:

- **Spin** *(`string` content)*

	- summary:
		- Takes a string of text and recursivly spins it returning the output as a string.

	- content: `string`
		- Text string to spin.
	
	- example:

		```
		var spun_text = Spinner.Spin("The {quick|fast} brown fox jumped over the lazy dog.");
		```

---

### License 

(The MIT License)

Copyright (c) 2011 Daniel Lamb <daniellmb.com>

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
'Software'), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.