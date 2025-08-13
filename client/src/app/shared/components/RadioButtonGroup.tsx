import { FormControl, FormControlLabel, Radio, RadioGroup } from "@mui/material";
import type { ChangeEvent } from "react";

type Props = {
    options: { value: string; label: string }[];
    selectedValue: string;
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;
}

export default function RadioButtonGroup({ options, selectedValue, onChange }: Props) {
  return (
    <FormControl>
        <RadioGroup value={selectedValue} onChange={onChange} sx={{my:0}}>
            {options.map(({value, label}) => (
                    <FormControlLabel 
                        key={label} control={<Radio />} label={label} value={value} />
                ))}
        </RadioGroup>
                
            </FormControl>
  )
}