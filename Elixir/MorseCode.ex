defmodule MorseCode do
  defp decode(".-"), do: 'A'
  defp decode("-..."), do: 'B'
  defp decode("-.-."), do: 'C'
  defp decode("-.."), do: 'D'
  defp decode("."), do: 'E'
  defp decode("..-."), do: 'F'
  defp decode("--."), do: 'G'
  defp decode("...."), do: 'H'
  defp decode(".."), do: 'I'
  defp decode(".---"), do: 'J'
  defp decode("-.-"), do: 'K'
  defp decode(".-.."), do: 'L'
  defp decode("--"), do: 'M'
  defp decode("-."), do: 'N'
  defp decode("---"), do: 'O'
  defp decode(".--."), do: 'P'
  defp decode("--.-"), do: 'Q'
  defp decode(".-."), do: 'R'
  defp decode("..."), do: 'S'
  defp decode("-"), do: 'T'
  defp decode("..-"), do: 'U'
  defp decode("...-"), do: 'V'
  defp decode(".--"), do: 'W'
  defp decode("-..-"), do: 'X'
  defp decode("-.--"), do: 'Y'
  defp decode("--.."), do: 'Z'

  defp decode(""), do: ' '

  defp decode(".----"), do: '1'
  defp decode("..---"), do: '2'
  defp decode("...--"), do: '3'
  defp decode("....-"), do: '4'
  defp decode("....."), do: '5'
  defp decode("-...."), do: '6'
  defp decode("--..."), do: '7'
  defp decode("---.."), do: '8'
  defp decode("----."), do: '9'
  defp decode("-----"), do: '0'

  def eval(s) when is_binary(s) do
    String.split(s, " ")
    |> Enum.map(&(decode &1))
    |> Enum.join("")
  end
end
