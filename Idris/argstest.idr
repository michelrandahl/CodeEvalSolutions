module Main


%inline
jscall : (fname : String) -> (ty : Type) ->
          {auto fty : FTy FFI_JS [] ty} -> ty
jscall fname ty = foreign FFI_JS fname ty

myfun : Int -> Int
myfun x =
  let stuff = jscall "function(x) { return x + 42; }"  in
  ?sfdsf

log : String -> JS_IntT ()
log js = jscall "console.log(%0)" (String -> JS_IntT ()) js



main : IO ()
main =
  log "hello js"
